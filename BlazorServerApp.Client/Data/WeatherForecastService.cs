namespace BlazorServerApp.Client.Data
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<WeatherForecast>> GetForecastAsync(DateOnly startDate)
        {
            var forecasts = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("api/weatherforecast");
            return forecasts ?? new List<WeatherForecast>();
        }
    }
}
