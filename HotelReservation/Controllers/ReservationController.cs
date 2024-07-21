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
    public class ReservationController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(HotelDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ConfirmReservation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmReservationGet(int roomId, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            if (checkInDate >= checkOutDate)
            {
                ModelState.AddModelError("", "Çıkış tarihi, giriş tarihinden sonra olmalıdır.");
                return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendirme veya uygun bir hata sayfası.
            }
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var room = await _context.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.RoomId == roomId);
            if (room == null)
            {
                return NotFound("Room not found.");
            }

            var totalPrice = (decimal)(checkOutDate - checkInDate).TotalDays * room.Price * numberOfGuests;

            var model = new ReservationViewModel
            {
                RoomId = roomId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                NumberOfGuests = numberOfGuests,
                RoomPrice = room.Price,
                TotalPrice = totalPrice,
                City = room.Hotel.City,
                Type = room.Type,
                // CustomerId alanını burada set etmiyoruz
            };

            return View("ConfirmReservation", model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmReservationPost(ReservationViewModel model)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Loglama
                }
                TempData["ErrorMessage"] = "Form verileri geçersiz. Lütfen tekrar deneyin.";
                return View("ConfirmReservation", model);
            }

            // Geçici CustomerId ile rezervasyonu ekliyoruz
            var reservation = new Reservation
            {
                RoomId = model.RoomId,
                CheckInDate = model.CheckInDate.Value,
                CheckOutDate = model.CheckOutDate.Value,
                NumberOfGuests = model.NumberOfGuests,
                TotalPrice = model.TotalPrice,
                ReservationStatus = "Beklemede",
                CustomerId = 1 // Geçici CustomerId
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Reservation successfully added.";

            return RedirectToAction("Create", "Payments", new { reservationId = reservation.ReservationId });
        }

        [HttpGet]
        public async Task<IActionResult> MyReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.IdentityUserId == userId);

            if (customer == null)
            {
                return NotFound("Customer not found for the current user.");
            }

            var reservations = await _context.Reservations
                .Where(r => r.CustomerId == customer.CustomerId)
                .Include(r => r.Room)
                .ThenInclude(r => r.Hotel)
                .ToListAsync();

            return View(reservations);
        }
    }
}
