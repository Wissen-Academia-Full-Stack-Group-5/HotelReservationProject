using Data.Contexts;
using Entity.Entites;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HotelReservation.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly HotelDbContext _context;

        public PaymentsController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int reservationId, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Room)
                .ThenInclude(r => r.Hotel)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservation == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.IdentityUserId == userId);

            if (customer == null)
            {
                return NotFound("Customer not found for the current user.");
            }

            var expirationDate = DateTime.TryParse(customer.ExpirationDate, out var parsedExpirationDate)
                ? parsedExpirationDate
                : (DateTime?)null;

            var model = new PaymentViewModel
            {
                ReservationId = reservationId,
                Amount = 0, // Initial amount set to 0, will be calculated in frontend
                PaymentDate = DateTime.Now,
                NumberOfGuests = numberOfGuests,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                CardHolderName = customer.CardHolderName,
                CardNumber = customer.CardNumber,
                ExpirationDate = expirationDate.HasValue ? expirationDate.Value : DateTime.MinValue,
                CVV = customer.CVV,
                Address = customer.Address,
                TCKimlikNo = customer.TCKimlikNo,
                RoomPrice = reservation.Room.Price // Room price is added to the model
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payment = new Payment
                {
                    ReservationId = model.ReservationId,
                    PaymentDate = model.PaymentDate,
                    Amount = model.Amount,
                    PaymentMethod = model.PaymentMethod
                };

                _context.Payments.Add(payment);

                var reservation = await _context.Reservations.FindAsync(model.ReservationId);
                if (reservation != null)
                {
                    reservation.ReservationStatus = "Onaylandı";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Reservations", new { id = model.ReservationId });
            }

            return View(model);
        }
    }
}
