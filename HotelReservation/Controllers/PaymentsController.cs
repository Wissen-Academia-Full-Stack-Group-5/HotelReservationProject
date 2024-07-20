using Data.Contexts;
using Data.Identity;
using Entity.Entites;
using Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class PaymentsController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PaymentsController(HotelDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int reservationId)
        {
            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservation == null)
            {
                return NotFound("Reservation not found.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var model = new PaymentViewModel
            {
                ReservationId = reservationId,
                Amount = reservation.TotalPrice,
                FirstName = user.Name,
                LastName = user.Surname,
                Email = user.Email,
                Phone = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Form verileri geçersiz. Lütfen tekrar deneyin.";
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            // Müşteri bilgilerini oluştur
            var customer = new Customer
            {
                IdentityUserId = userId,
                FirstName = user.Name,
                LastName = user.Surname,
                Email = user.Email,
                Phone = user.PhoneNumber,
                CardHolderName = model.CardHolderName,
                CardNumber = model.CardNumber,
                ExpirationDate = model.ExpirationDate,
                CVV = model.CVV,
                Address = model.Address,
                TCKimlikNo = model.TCKimlikNo
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Rezervasyon güncelleme işlemi
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationId == model.ReservationId);
            if (reservation == null)
            {
                TempData["ErrorMessage"] = "Reservation not found.";
                return View(model);
            }
            reservation.CustomerId = customer.CustomerId;

            // Ödeme bilgilerini kaydet
            var payment = new Payment
            {
                ReservationId = model.ReservationId,
                PaymentDate = DateTime.Now,
                Amount = model.Amount,
                PaymentMethod = model.PaymentMethod
            };

            _context.Payments.Add(payment);

            // Eğer ödeme yöntemi "Nakit" değilse, rezervasyon durumunu "Onaylandı" olarak güncelle
            if (model.PaymentMethod != "Nakit")
            {
                reservation.ReservationStatus = "Onaylandı";
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Payment successfully processed.";
            return RedirectToAction("Success");
        }

        [HttpGet]
        public async Task<IActionResult> Success()
        {
            return View(Success);
        }
    }
}
