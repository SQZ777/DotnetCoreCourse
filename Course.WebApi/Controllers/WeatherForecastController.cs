using System.Collections.Generic;
using System.Linq;
using Course.WebApi.Interfaces;
using Course.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Course.WebApi.Repositories;

namespace Course.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastService.Read();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post([FromBody]WeatherForecast weatherForecast)
        {
            return _weatherForecastService.Create(weatherForecast);
        }

        [HttpPut("{id}")]
        public IEnumerable<WeatherForecast> Put([FromBody]WeatherForecast weatherForecast, [FromRoute]int id)
        {
            return _weatherForecastService.Update(weatherForecast, id);
        }

        [HttpDelete("{id}")]
        public IEnumerable<WeatherForecast> Delete(int id)
        {
            return _weatherForecastService.Delete(id);
        }
    }
}
