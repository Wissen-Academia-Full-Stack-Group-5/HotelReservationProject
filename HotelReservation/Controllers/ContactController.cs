using Microsoft.AspNetCore.Mvc;
using HotelReservation.Models;
using Entity.ViewModels;

namespace HotelReservation.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContactForm(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // İletişim formu verilerini işle
                TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi.";
                return RedirectToAction("Index");
            }
            return View("Index", model);
        }
    }
}
