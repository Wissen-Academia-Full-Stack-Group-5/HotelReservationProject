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
                return RedirectToAction("Index", "Home");
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

            // Oda müsaitlik kontrolü
            var isRoomBooked = await _context.Reservations.AnyAsync(r => r.RoomId == roomId &&
                                             ((checkInDate >= r.CheckInDate && checkInDate < r.CheckOutDate) ||
                                             (checkOutDate > r.CheckInDate && checkOutDate <= r.CheckOutDate)));

            if (!room.IsAvailable || isRoomBooked)
            {
                TempData["ErrorMessage"] = "Oda müsait değil.";
                return RedirectToAction("Detail", "Home", new { id = room.HotelId });
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
                ReservationStatus = "Beklemede"
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

            var room = await _context.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.RoomId == model.RoomId);
            if (room == null)
            {
                TempData["ErrorMessage"] = "Oda bulunamadı.";
                return RedirectToAction("Detail", "Home", new { id = model.RoomId });
            }

            var isRoomBooked = await _context.Reservations.AnyAsync(r => r.RoomId == model.RoomId &&
                                             ((model.CheckInDate >= r.CheckInDate && model.CheckInDate < r.CheckOutDate) ||
                                             (model.CheckOutDate > r.CheckInDate && model.CheckOutDate <= r.CheckOutDate)));

            if (!room.IsAvailable || isRoomBooked)
            {
                TempData["ErrorMessage"] = "Oda müsait değil.";
                return RedirectToAction("Detail", "Home", new { id = room.HotelId });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Login", "Account");
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.IdentityUserId == userId);
            if (customer == null)
            {
                customer = new Customer
                {
                    IdentityUserId = userId,
                    FirstName = user.Name,
                    LastName = user.Surname,
                    Email = user.Email,
                    Phone = user.PhoneNumber
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }

            var reservation = new Reservation
            {
                RoomId = model.RoomId,
                CheckInDate = model.CheckInDate.Value,
                CheckOutDate = model.CheckOutDate.Value,
                NumberOfGuests = model.NumberOfGuests,
                TotalPrice = model.TotalPrice,
                ReservationStatus = "Beklemede",
                CustomerId = customer.CustomerId
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Rezervasyon başarıyla oluşturuldu.";

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
