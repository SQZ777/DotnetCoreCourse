using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.WebApi.Models;

namespace Course.WebApi.Interfaces
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Create(WeatherForecast weatherForecast);
        IEnumerable<WeatherForecast> Read();
        IEnumerable<WeatherForecast> Update(WeatherForecast weatherForecast, int id);
        IEnumerable<WeatherForecast> Delete(int id);
    }
}
