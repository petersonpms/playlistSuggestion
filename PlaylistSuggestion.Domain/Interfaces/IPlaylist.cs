using PlaylistSuggestion.Domain.DTO;

namespace PlaylistSuggestion.Domain.Interfaces
{
    public interface IPlaylist
    {
        Task<WeatherForecastDTO> GetPlaylistByCity(string city);
    }
}
