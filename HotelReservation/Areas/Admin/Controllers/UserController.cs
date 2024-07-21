using Entity.Services;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetAll();
            return View(user);
        }
        public async Task<ActionResult> Edit(int id)
        {
            var hotel = await _userService.GetReservationById(id);

            return View(hotel);
        }


        [HttpPost]
        public async Task<ActionResult> Edit(CustomerViewModel customer)
        {

            await _userService.Update(customer);
            return RedirectToAction("Index", "Admin");
        }
        public async Task<ActionResult> Delete(int id)
        {
            var hotel = await _userService.GetReservationById(id);
            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
