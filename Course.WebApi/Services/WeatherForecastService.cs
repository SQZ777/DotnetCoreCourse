using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.WebApi.Controllers;
using Course.WebApi.Interfaces;
using Course.WebApi.Models;
using Course.WebApi.Repositories;
using Microsoft.Extensions.Logging;

namespace Course.WebApi.Services
{
    public class WeatherForecastService :IWeatherForecastService
    {
        private readonly WeatherDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastService(ILogger<WeatherForecastController> logger, WeatherDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IEnumerable<WeatherForecast> Create(WeatherForecast weatherForecast)
        {
            _context.WeatherForecasts.Add(weatherForecast);
            _context.SaveChanges();
            return _context.WeatherForecasts.ToArray();
        }

        public IEnumerable<WeatherForecast> Read()
        {
            return _context.WeatherForecasts.ToArray();
        }

        public IEnumerable<WeatherForecast> Update(WeatherForecast weatherForecast, int id)
        {
            var item = _context.WeatherForecasts.SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                _logger.LogDebug("資料存在");
                item.Summary = weatherForecast.Summary;
                item.TemperatureC = weatherForecast.TemperatureC;
                item.Date = weatherForecast.Date;
                _context.SaveChanges();
            }
            else
            {
                _logger.LogDebug("資料不存在");
            }
            return _context.WeatherForecasts.ToArray();
        }

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
