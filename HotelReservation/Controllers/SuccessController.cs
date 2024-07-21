using Data.Contexts;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Controllers
{
    public class SuccessController : Controller
    {
        private readonly HotelDbContext _context;

        public SuccessController(HotelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Success(int reservationId)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Room)
                .ThenInclude(r => r.Hotel)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservation == null)
            {
                return NotFound("Reservation not found.");
            }

            var model = new SuccessViewModel
            {
                HotelName = reservation.Room.Hotel.Name,
                RoomType = reservation.Room.Type,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                TotalPrice = reservation.TotalPrice,
                HotelAddress = $"{reservation.Room.Hotel.Address}, {reservation.Room.Hotel.City}, {reservation.Room.Hotel.Country}"
            };

            return View(model);
        }



    }
}
