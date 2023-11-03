using Microsoft.AspNetCore.Mvc;
using WEERAPI.Models;

namespace WEERAPI
{
    [ApiController]
    [Route("WEERAPI/[controller]")]
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