namespace ClimaTempoWebAPI.Models
{
    public class WeatherData
    {
        public required string By { get; set; }
        public bool ValidKey { get; set; }
        public required Results Results { get; set; }
        public double ExecutionTime { get; set; }
        public bool FromCache { get; set; }

    }
    public class Results
    {
        public int Temp { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ConditionCode { get; set; }
        public string Description { get; set; }
        public string Currently { get; set; }
        public string City { get; set; }
        public string ImgId { get; set; }
        public int Humidity { get; set; }
        public double Cloudiness { get; set; }
        public double Rain { get; set; }
        public string WindSpeedy { get; set; }
        public int WindDirection { get; set; }
        public string WindCardinal { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string MoonPhase { get; set; }
        public string ConditionSlug { get; set; }
        public string CityName { get; set; }
        public string Timezone { get; set; }
        public Forecast[] Forecast { get; set; }
        public string Cref { get; set; }
    }

    public class Forecast
    {
        public string Date { get; set; }
        public string Weekday { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public double Cloudiness { get; set; }
        public double Rain { get; set; }
        public int RainProbability { get; set; }
        public string WindSpeedy { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
    }
}
