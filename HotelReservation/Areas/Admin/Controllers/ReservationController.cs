using Entity.Services;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace HotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            var reservation = await reservationService.GetAll();
            return View(reservation);
        }
        public async Task<ActionResult> Edit(int id)
        {
            var hotel = await reservationService.GetReservationById(id);

            return View(hotel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ReservationViewModel reservation)
        {

            await reservationService.Update(reservation);
            return RedirectToAction("Index", "Admin");
        }
        public async Task<ActionResult> Delete(int id)
        {
            var hotel = await reservationService.GetReservationById(id);
            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await reservationService.Delete(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
