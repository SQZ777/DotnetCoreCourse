using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Course.WebApi.Models;

namespace Course.WebApi.Repositories
{
    
    public class WeatherDbContext : DbContext
    {
        // private IConfiguration Configuration { get; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}