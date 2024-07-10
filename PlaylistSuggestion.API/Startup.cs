using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlaylistSuggestion.Domain.Interfaces;
using PlaylistSuggestion.Infra;
using PlaylistSuggestion.Service.Services;
using SimpleHttpFunction;

namespace PlaylistSuggestion.API
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
        {
            services
                .AddSingleton<IPlaylist, Playlist>()
                .AddSingleton<IDBConnection, DBConnection>()
                .AddSingleton<IWeatherForecastAPI, WeatherForecastAPI>();
        }
    }
}
