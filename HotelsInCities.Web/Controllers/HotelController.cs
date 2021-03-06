using HotelsInCities.Application.Intefaces.Dtos.Hotel;
using HotelsInCities.Application.Intefaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelsInCities.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ICityService _cityService;

        public HotelController(IHotelService hotelService, ICityService cityService)
        {
            _hotelService = hotelService;
            _cityService = cityService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            var result = await _hotelService.GetAllByCityId(id);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            SelectList cities = new SelectList(await _cityService.GetAllForHotelCreation(), "Id", "Name");
            ViewBag.Cities = cities;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelDto hotelDTO)
        {
            //this.User.Identity.IsAuthenticated
            try
            {
                await _hotelService.Create(hotelDTO);
                return RedirectToAction("Index", "City");
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _hotelService.GetById(id);
            SelectList cities = new SelectList(await _cityService.GetAll(), "Id", "Name", hotel.CityId);
            ViewBag.Cities = cities;
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HotelDto hotelDTO)
        {
            try
            {
                await _hotelService.Update(id, hotelDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hotel = await _hotelService.GetById(id);
            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _hotelService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
