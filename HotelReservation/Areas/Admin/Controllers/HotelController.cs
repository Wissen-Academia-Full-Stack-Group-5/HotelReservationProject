using Entity.Entites;
using Entity.Repositories;
using Entity.Services;
using Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
public class HotelController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IHotelRepository _hotelRepository;
    private readonly IRoomService _roomService;

    public HotelController(IHotelService hotelService, IHotelRepository hotelRepository, IRoomService roomService)
    {
        _hotelService = hotelService;
        _hotelRepository = hotelRepository;
        _roomService = roomService;
    }
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> Index()
    {
        var hotel = await _hotelService.GetAll();
        return View(hotel);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(HotelViewModel model)
    {


        // Burada HotelViewModel'i Hotel entity'sine dönüştürüp kaydetme işlemini yapabiliriz
        var hotel = new Hotel
        {
            Name = model.Name,
            City = model.City,
            Address = model.Address,
            Country = model.Country,
            Description = model.Description,
            Rating = model.Rating,
            PictureUrl = model.PictureUrl,


            // Diğer özellikler
        };

        _hotelRepository.Add(hotel); // Hotel'i repository üzerinden ekleyelim

        /*return RedirectToAction("Index");*/ // Hotels listesine yönlendir


        // ModelState.IsValid false ise, tekrar formu gösterelim
        return View(model);
    }
    public async Task<ActionResult> Edit(int id)
    {
        var hotel = await _hotelService.GetHotelByHotelId(id);

        return View(hotel);
    }


    [HttpPost]
    public async Task<ActionResult> Edit(HotelViewModel hotel)
    {
        if (ModelState.IsValid)
        {
            await _hotelService.Update(hotel);
            return RedirectToAction("Index");
        }

        return View(hotel);
    }
    public async Task<ActionResult> Delete(int id)
    {
        var hotel = await _hotelService.GetHotelByHotelId(id);
        return View(hotel);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        await _hotelService.Delete(id);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Room(int Id)
    {
        var rooms = await _roomService.Get(Id);
        return View(rooms); // List<RoomViewModel> döndürüyoruz
    }
}