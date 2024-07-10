using PlaylistSuggestion.Domain.DTO;
using PlaylistSuggestion.Domain.Enum;
using PlaylistSuggestion.Domain.Interfaces;

namespace PlaylistSuggestion.Service.Services
{
    public class Playlist : IPlaylist
    {

        private readonly IWeatherForecastAPI _weatherForecastAPI;
        //private readonly ISpotity _spotity;
        private readonly IDBConnection _dbConnection;
        public Playlist(IWeatherForecastAPI weatherForecastAPI, IDBConnection dbConnection)
        {
            _weatherForecastAPI = weatherForecastAPI;
            _dbConnection = dbConnection;
        }

        public async Task<List<MusicDTO>> GetPlaylistByCity(string city)
        {
            try
            {
                WeatherForecastDTO weatherForecast = await _weatherForecastAPI.GetTemperatureByCity(city);
                int temp = weatherForecast.Results.Temp;

                //PS. Não consegui trazer uma playlist do spotify por problemas de autenticação, mas pode ser uma opção futura
                if (temp > 25)
                    return await _dbConnection.GetPlaylistByMusicalGenre(MusicalGenreEnum.POP);
                else if (temp >= 10 && temp <= 25)
                    return await _dbConnection.GetPlaylistByMusicalGenre(MusicalGenreEnum.ROCK);
                else
                    return await _dbConnection.GetPlaylistByMusicalGenre(MusicalGenreEnum.CLASSIC);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
