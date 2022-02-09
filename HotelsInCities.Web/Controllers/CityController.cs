using HotelsInCities.Application.Intefaces.Dtos.City;
using HotelsInCities.Application.Intefaces.Interfaces;
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
        public async Task<IActionResult> Create(CityDto cityDTO)
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
        public async Task<IActionResult> Edit(int id, CityDto city)
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

        public ActionResult WeatherForecast(int id)
        {
            return RedirectToAction("Index", "WeatherForecast", new {id = id});
        }
    }
}
