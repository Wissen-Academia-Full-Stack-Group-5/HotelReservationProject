using Microsoft.AspNetCore.Mvc;
using HotelReservation.Models;

namespace HotelReservation.Controllers
{
    public class PrivacyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
