using ClimaTempoWebAPI.Models;

namespace ClimaTempoWebAPI.Services.External
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherData(double latitude, double longitude);
    }
}
