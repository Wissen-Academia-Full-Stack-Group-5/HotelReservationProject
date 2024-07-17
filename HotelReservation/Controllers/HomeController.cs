using Entity.Entites;
using Entity.Services;
using Entity.ViewModels;
using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;

        public HomeController(ILogger<HomeController> logger, IHotelService hotelService, IRoomService roomService)
        {
            _logger = logger;
            _hotelService = hotelService;
            _roomService = roomService;
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

        public async Task<IActionResult> Filter(DateTime checkInDate, DateTime checkOutDate, string City, string Type)
        {
            if (checkInDate == default || checkOutDate == default || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Type))
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun.");
                var cities = await _hotelService.GetCities();
                var model = new SearchViewModel
                {
                    Cities = cities,
                    CheckInDate = checkInDate,
                    CheckOutDate = checkOutDate,
                    City = City,
                    Type = Type
                };
                return View("Index", model);
            }

            var hotel = await _hotelService.GetFilteredHotels(checkInDate, checkOutDate, City, Type);
            return View(hotel);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            var rooms = await _roomService.Get(Id);
            return View(rooms); // List<RoomViewModel> döndürüyoruz
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
