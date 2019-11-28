using System.Collections.Generic;
using System.Linq;
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
        private readonly WeatherDbContext _context;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _context.WeatherForecasts.ToArray();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post([FromBody]WeatherForecast weatherForecast)
        {
            _context.WeatherForecasts.Add(weatherForecast);
            _context.SaveChanges();
            return _context.WeatherForecasts.ToArray();
        }

        [HttpPut("{id}")]
        public IEnumerable<WeatherForecast> Put([FromBody]WeatherForecast weatherForecast, [FromRoute]int id)
        {
            var item = _context.WeatherForecasts.SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                _logger.LogDebug("資料存在");
                item.Summary = weatherForecast.Summary;
                item.TemperatureC = weatherForecast.TemperatureC;
                item.Date = weatherForecast.Date;
                _context.SaveChanges();
            } else{
                 _logger.LogDebug("資料不存在");
            }
            return _context.WeatherForecasts.ToArray();
        }

        [HttpDelete("{id}")]
        public IEnumerable<WeatherForecast> Delete(int id)
        {
            var item = _context.WeatherForecasts.SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.WeatherForecasts.Remove(item);
                _context.SaveChanges();
            }
            return _context.WeatherForecasts.ToArray();
        }
    }
}
