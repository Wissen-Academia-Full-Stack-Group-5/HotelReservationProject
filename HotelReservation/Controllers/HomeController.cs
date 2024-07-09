using Entity.Entites;
using Entity.Services;
using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Diagnostics;

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

		public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Filter()
        {
			var hotel = await _hotelService.GetAll();
			return View(hotel);
		}
        public async Task<IActionResult> Detail(int id,int hotelid)
        {
            //var hotel = await _roomService.Get(id);
            //return View(hotel);
   //         var rooms = _roomService.Get(id,hotelid);
			//return View(rooms);
			var roomViewModel = await _roomService.Get(hotelid, id);

			if (roomViewModel == null)
			{
				return NotFound(); // İstenen oda bulunamadıysa 404 dönebilirsiniz.
			}

			return View(roomViewModel); // RoomViewModel'i view'a döndürüyoruz
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
