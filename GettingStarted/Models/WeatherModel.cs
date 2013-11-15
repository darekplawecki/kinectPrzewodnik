namespace Przewodnik.Models
{
    public class WeatherModel
    {
        public string WeatherImage { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public string NameDay { get; set; }

        public WeatherModel()
        {
            WeatherImage = string.Empty;
            Temperature = string.Empty;
            Description = string.Empty;
            NameDay = string.Empty;
        }

        public WeatherModel(string weatherImage, string temperature, string description, string nameDay)
        {
            this.WeatherImage = weatherImage;
            this.Temperature = temperature;
            this.Description = description;
            this.NameDay = nameDay;
        }
    }
}
