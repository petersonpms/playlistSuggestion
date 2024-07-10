using PlaylistSuggestion.Domain.DTO;

namespace PlaylistSuggestion.Domain.Interfaces
{
    public interface IWeatherForecastAPI
    {
        Task<WeatherForecastDTO> GetTemperatureByCity(string city);
    }
}
