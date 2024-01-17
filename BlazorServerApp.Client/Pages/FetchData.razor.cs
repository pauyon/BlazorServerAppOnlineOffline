using BlazorServerApp.Client.Services.WeatherForecastService;
using BlazorServerApp.Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Client.Pages
{
    public partial class FetchData
    {
        private List<WeatherForecast>? forecasts;

        [Inject]
        public IWeatherForecastService? ForecastService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService!.GetForecastAsync();
        }
    }
}
