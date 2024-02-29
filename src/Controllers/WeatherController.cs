using ClimaTempoWebAPI.Models;
using ClimaTempoWebAPI.Services.External;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController(IWeatherService weatherService) : ControllerBase
    {
        private readonly IWeatherService _weatherService = weatherService;

        [HttpGet]
        public async Task<IActionResult> GetWeather(double latitude, double longitude)
        {
            try
            {
                return Ok(await _weatherService.GetWeatherData(latitude, longitude));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter os dados meteorológicos: {ex.Message}");
            }
        }
    }
}
