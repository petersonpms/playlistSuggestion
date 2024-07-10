using Google.Cloud.Functions.Framework;
using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PlaylistSuggestion.API;
using PlaylistSuggestion.Domain.Interfaces;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleHttpFunction;

[FunctionsStartup(typeof(Startup))]
public class Function : IHttpFunction
{
    private readonly ILogger _logger;
    private readonly IPlaylist _playlist;
    public Function(ILogger<Function> logger, IPlaylist playlist)
    {
        _logger = logger;
        _playlist = playlist;
    }

    public async Task HandleAsync(HttpContext context)
    {
        HttpRequest request = context.Request;

        using TextReader reader = new StreamReader(request.Body);
        string body = await reader.ReadToEndAsync();
        if (body.Length > 0)
        {
            try
            {
                JsonElement json = JsonSerializer.Deserialize<JsonElement>(body);

                // Second key validation
                if (json.TryGetProperty("sj0bvrWbBE3SZMAdPj4Ag6ydE", out JsonElement messageElement))
                {
                    if (messageElement.TryGetProperty("city", out JsonElement parameter))
                    {
                        string city = messageElement.GetProperty("city").ToString();
                        if (string.IsNullOrEmpty(city))
                        {
                            string error = "Error. The city field is required.";
                            _logger.LogError(error);
                            await context.Response.WriteAsync(error);
                        }
                        else
                        {
                            var response = _playlist.GetPlaylistByCity(city);

                            if (response != null)
                                await context.Response.WriteAsJsonAsync(response);
                            else
                            {
                                string error = "Error. Verify your API communication.";
                                _logger.LogError(error);
                                await context.Response.WriteAsync(error);
                            }
                        }
                    }
                    else
                    {
                        string error = "Error. Invalid parameter.";
                        _logger.LogError(error);
                        await context.Response.WriteAsync(error);
                    }
                }
                else
                {
                    _logger.LogError("Error. Invalid main parameter.");
                    context.Response.StatusCode = 403;
                }
            }
            catch (JsonException parseException)
            {
                string error = "Error. Parsing JSON request";
                _logger.LogError(parseException, error);
                await context.Response.WriteAsJsonAsync(parseException);
            }
        }
        else
        {
            _logger.LogError("Error. Invalid body context.");
            context.Response.StatusCode = 403;
        }
    }
}
