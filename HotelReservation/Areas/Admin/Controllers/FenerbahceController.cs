using Entity.Services;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
public class FenerbahceController : Controller
{
    private readonly IRoomService _roomService;

    public FenerbahceController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<ActionResult> Index(int hotelId)
    {
        var rooms = await _roomService.GetRoomsByHotelId(hotelId);
        return View(rooms);
    }

    public async Task<ActionResult> Edit(int id)
    {
        var room = await _roomService.GetRoomById(id);


        return View(room);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(RoomViewModel room)
    {
        if (ModelState.IsValid)
        {
            await _roomService.Update(room);
            return RedirectToAction("Index", new { RoomId = room.RoomId });
        }

        return View(room);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        await _roomService.Delete(id);
        return RedirectToAction("Index");
    }
}
