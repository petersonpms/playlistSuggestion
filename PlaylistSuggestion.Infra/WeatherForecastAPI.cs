using Newtonsoft.Json;
using PlaylistSuggestion.Domain.DTO;
using PlaylistSuggestion.Domain.Interfaces;

namespace PlaylistSuggestion.Infra
{
    public class WeatherForecastAPI : IWeatherForecastAPI
    {
        const string API_URL = "https://api.hgbrasil.com/weather?key=c546f5ec&city_name=";
        public async Task<WeatherForecastDTO> GetTemperatureByCity(string city)
        {
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.GetAsync(API_URL + city);
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<WeatherForecastDTO>(jsonResponse);
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }
    }
}
