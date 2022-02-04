using HotelsInCities.Services.Intefaces.DTO_s;
using HotelsInCities.Services.Intefaces.DTO_s.City;
using HotelsInCities.Services.Intefaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelsInCities.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _cityService.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityDTO cityDTO)
        {
            try
            {
                await _cityService.Create(cityDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityService.GetById(id);
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CityDTO city)
        {
            try
            {
                await _cityService.Update(id, city);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityService.GetById(id);
            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _cityService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Hotels(int id)
        {
            return RedirectToAction("Index", "Hotel", new { id = id });
        }

        public ActionResult WeatherForecast(int cityId)
        {
            return RedirectToAction("Index", "WeatherForecast", new {id = cityId});
        }
    }
}
