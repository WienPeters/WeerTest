using Microsoft.AspNetCore.Mvc;
using WeerTest;

namespace WEERAPI
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        Weerhalen wh = new Weerhalen();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Getweather(string stad)
        {
            return (wh.StadsWeer(stad));
            
        }
    }
}