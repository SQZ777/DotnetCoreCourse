using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.WebApi.Interfaces;
using Course.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course.WebApi.Controllers
{

    [Route("[controller]/[Action]")]
    public class WeatherForecastViewController : Controller
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastViewController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        
        public IActionResult List()
        {
            return View(_weatherForecastService.Read());
        }

        public IActionResult Edit(int id)
        {
            var result = _weatherForecastService.Read().FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return RedirectToAction("List", "WeatherForecastView");
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit([FromForm]WeatherForecast weatherForecast, [FromQuery]int id)
        {
            _weatherForecastService.Update(weatherForecast, id);
            return RedirectToAction("List", "WeatherForecastView");
        }

        public IActionResult Delete(int id)
        {
            _weatherForecastService.Delete(id);
            return RedirectToAction("List", "WeatherForecastView");
        }
    }
}
