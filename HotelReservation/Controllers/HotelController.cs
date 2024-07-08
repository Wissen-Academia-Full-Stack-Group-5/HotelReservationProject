using AutoMapper;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;

public class HotelController : Controller
{
    private readonly IHotelService _hotelservice;
    private readonly IMapper _mapper;

    public HotelController(IHotelService hotelservice, IMapper mapper)
    {
        _hotelservice = hotelservice ?? throw new ArgumentNullException(nameof(hotelservice));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ActionResult> HotelDetail(int id)
    {
        var hotel = await _hotelservice.Get(id);
        if (hotel == null)
        {
            return NotFound();
        }
        return View(hotel);
    }

    public IActionResult Index()
    {
        return View();
    }
}
