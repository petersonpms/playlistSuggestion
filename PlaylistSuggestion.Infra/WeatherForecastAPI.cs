using Newtonsoft.Json;
using PlaylistSuggestion.Domain.DTO;
using PlaylistSuggestion.Domain.Interfaces;
using System.Text.Json;

namespace PlaylistSuggestion.Infra
{
    public class WeatherForecastAPI : IWeatherForecastAPI
    {
        const string API_URL = "https://api.hgbrasil.com/weather?key=c546f5ec&city_name=";
        async Task<WeatherForecastDTO> IWeatherForecastAPI.GetTemperatureByCity(string city)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(API_URL + city);
                string stringResponse = await response.Content.ReadAsStringAsync();
                JsonElement json = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(stringResponse);
                return JsonConvert.DeserializeObject<WeatherForecastDTO>(json.GetProperty("results").ToString());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}