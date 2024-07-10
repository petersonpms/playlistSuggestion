using PlaylistSuggestion.Domain.DTO;
using PlaylistSuggestion.Domain.Enum;
using PlaylistSuggestion.Domain.Interfaces;
using System;
using System.Threading.Tasks;

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

        public async Task<WeatherForecastDTO> GetPlaylistByCity(string city)
        {
            try
            {
                WeatherForecastDTO weatherForecast = await _weatherForecastAPI.GetTemperatureByCity(city);
                int temp = weatherForecast.Temp;

                //PS. Não consegui trazer uma playlist do spotify por problemas de autenticação, mas pode ser uma opção futura
                if (temp > 25)
                {
                    weatherForecast.Musics = await _dbConnection.GetPlaylistByMusicalGenre(MusicalGenreEnum.Pop);
                    weatherForecast.MusicalGenre = MusicalGenreEnum.Pop.ToString();
                }
                else if (temp >= 10 && temp <= 25)
                {
                    weatherForecast.Musics = await _dbConnection.GetPlaylistByMusicalGenre(MusicalGenreEnum.Rock);
                    weatherForecast.MusicalGenre = MusicalGenreEnum.Rock.ToString();
                }
                else
                {
                    weatherForecast.Musics = await _dbConnection.GetPlaylistByMusicalGenre(MusicalGenreEnum.Classic);
                    weatherForecast.MusicalGenre = MusicalGenreEnum.Classic.ToString();
                }

                return weatherForecast;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
