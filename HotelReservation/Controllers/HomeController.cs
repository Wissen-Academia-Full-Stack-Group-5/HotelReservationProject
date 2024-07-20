using Entity.Entites;
using Entity.Services;
using Entity.ViewModels;
using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;
        private readonly IReservationService _reservationService;

        public HomeController(ILogger<HomeController> logger, IHotelService hotelService, IRoomService roomService, IReservationService reservationService)
        {
            _logger = logger;
            _hotelService = hotelService;
            _roomService = roomService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _hotelService.GetCities();
            var model = new SearchViewModel
            {
                Cities = cities
            };
            return View(model);
        }

        public async Task<IActionResult> Filter(DateTime checkInDate, DateTime checkOutDate, string City, int NumberOfGuests)
        {
            if (checkInDate == default || checkOutDate == default || string.IsNullOrEmpty(City) || NumberOfGuests <= 0)
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun.");
                var cities = await _hotelService.GetCities();
                var model = new SearchViewModel
                {
                    Cities = cities,
                    CheckInDate = checkInDate,
                    CheckOutDate = checkOutDate,
                    City = City,
                    NumberOfGuests = NumberOfGuests
                };
                return View("Index", model);
            }

            ViewData["CheckInDate"] = checkInDate.ToString("yyyy-MM-dd");
            ViewData["CheckOutDate"] = checkOutDate.ToString("yyyy-MM-dd");
            ViewData["NumberOfGuests"] = NumberOfGuests;

            string Type;
            if (NumberOfGuests == 1)
                Type = "Tek Kişilik";
            else if (NumberOfGuests == 2)
                Type = "Çift Kişilik";
            else if (NumberOfGuests <= 4)
                Type = "Aile Odası";
            else
                Type = "Süit";

            var hotel = await _hotelService.GetFilteredHotels(checkInDate, checkOutDate, City, Type);
            return View(hotel);
        }



        public async Task<IActionResult> Detail(int id, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            var rooms = await _roomService.GetRoomsByHotel(id, checkInDate, checkOutDate);
            var hotel = await _hotelService.GetHotelById(id);

            var model = rooms.Select(room => new RoomViewModel
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                Type = room.Type,
                Price = room.Price,
                Description = room.Description,
                IsAvailable = room.IsAvailable,
                City = hotel.City,
                Country = hotel.Country,
                PictureUrl = room.PictureUrl
            }).ToList();

            ViewData["CheckInDate"] = checkInDate.ToString("yyyy-MM-dd");
            ViewData["CheckOutDate"] = checkOutDate.ToString("yyyy-MM-dd");
            ViewData["NumberOfGuests"] = numberOfGuests;

            return View(model);
        }





        public IActionResult AllHotels()
        {
            var hotels = _hotelService.GetAllHotelsGroupedByCity();
            return View(hotels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
