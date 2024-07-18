using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
