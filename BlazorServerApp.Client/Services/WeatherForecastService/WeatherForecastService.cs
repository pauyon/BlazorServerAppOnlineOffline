using BlazorServerApp.Domain.Models;

namespace BlazorServerApp.Client.Services.WeatherForecastService
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<WeatherForecast>> GetForecastAsync()
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weatherforecast");
            return forecasts ?? new List<WeatherForecast>();
        }
    }
}
