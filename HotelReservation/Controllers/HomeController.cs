using Entity.Services;
using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService _hotelService;

		public HomeController(ILogger<HomeController> logger, IHotelService hotelService)
		{
			_logger = logger;
			_hotelService = hotelService;
		}

		public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Filter(DateTime CheckInDate, DateTime CheckOutDate)
        {
            var availableHotels = await _hotelService.GetFilteredHotels(CheckInDate, CheckOutDate);
            return View(availableHotels);
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
