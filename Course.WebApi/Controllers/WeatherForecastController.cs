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
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        public WeatherForecastController(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastRepository.Read();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post([FromBody]WeatherForecast weatherForecast)
        {
            return _weatherForecastRepository.Create(weatherForecast);
        }

        [HttpPut("{id}")]
        public IEnumerable<WeatherForecast> Put([FromBody]WeatherForecast weatherForecast, [FromRoute]int id)
        {
            return _weatherForecastRepository.Update(weatherForecast, id);
        }

        [HttpDelete("{id}")]
        public IEnumerable<WeatherForecast> Delete(int id)
        {
            return _weatherForecastRepository.Delete(id);
        }
    }
}
