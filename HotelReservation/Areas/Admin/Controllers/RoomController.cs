using Entity.Services;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IProService _proService;

        public RoomController(IRoomService roomService, IProService proService)
        {
            _roomService = roomService;
            _proService = proService;
        }

        public async Task<ActionResult> Index(int Id)
        {
            var rooms = await _roomService.Get(Id);
            return View(rooms); // List<RoomViewModel> döndürüyoruz
        }

        public async Task<IActionResult> Edit(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomViewModel room)
        {
            if (ModelState.IsValid!)
            {
                await _roomService.Update(room);
                return RedirectToAction("Index", new { hotelId = room.HotelId });
            }
            else
            {
                // ModelState hatalarını loglayın
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(room);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _roomService.GetRoomById(id);


            return View(room);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int RoomId)
        {
            var result = await _roomService.DeleteRoom(RoomId);


            return RedirectToAction("Index","Admin",  new { RoomId = RoomId });
        }
        public IActionResult Add(int id) // Otel ID'sini parametre olarak al
        {
            var roomViewModel = new RoomViewModel { HotelId = id };
            return View(roomViewModel);
        }

        [HttpPost]
        
        public async Task<IActionResult> Add(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _roomService.Add(roomViewModel);
                if (result)
                {
                    return RedirectToAction("Index", "Hotel", new { id = roomViewModel.HotelId }); // Otel sayfasına yönlendir
                }
                else
                {
                    // ... hata mesajı ekle ...
                }
            }

            return View(roomViewModel); // Hata durumunda formu tekrar göster
        }
    }
}
