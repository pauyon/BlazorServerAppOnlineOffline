using BlazorServerApp.Domain.Models;

namespace BlazorServerApp.Client.Services.WeatherForecastService
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>> GetForecastAsync();
    }
}