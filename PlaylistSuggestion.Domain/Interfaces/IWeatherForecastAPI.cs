﻿using PlaylistSuggestion.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistSuggestion.Domain.Interfaces
{
    public interface IWeatherForecastAPI
    {
        Task<WeatherForecastDTO> GetTemperatureByCity(string city);
    }
}
