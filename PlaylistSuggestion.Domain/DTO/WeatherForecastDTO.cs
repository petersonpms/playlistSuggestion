namespace PlaylistSuggestion.Domain.DTO
{
    public class WeatherForecastDTO
    {
        public string MusicalGenre { get; set; }
        public int Temp { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Currently { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string TimeZone { get; set; }
        public List<MusicDTO> Musics { get; set; }
    }
}
