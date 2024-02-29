using ClimaTempoWebAPI.Models;
using Newtonsoft.Json;

namespace ClimaTempoWebAPI.Services.External
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public WeatherService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.hgbrasil.com/");
        }

        public async Task<WeatherData> GetWeatherData(double latitude, double longitude)
        {
             string apiKey = _configuration["HGWeatherApi:ApiKey"];
            HttpResponseMessage response = await _httpClient.GetAsync($"weather?key={apiKey}&lat={latitude}&lon={longitude}&user_ip_remote");

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                WeatherData? weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonString);

                return weatherData;
            }
            else
            {
                throw new Exception($"Failed to fetch weather data. Status code: {response.StatusCode}");
            }
        }
    }
}
