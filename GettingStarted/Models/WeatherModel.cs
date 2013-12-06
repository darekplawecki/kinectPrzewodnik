using System.ComponentModel;
namespace Przewodnik.Models
{
    public class WeatherModel
    {
        public string WeatherImage { get; set; }
        public string Temperature { get; set; }

        public WeatherModel()
        {
            WeatherImage = string.Empty;
            Temperature = string.Empty;
        }

        public WeatherModel(string weatherImage, string temperature)
        {
            this.WeatherImage = weatherImage;
            this.Temperature = temperature;
        }
    }
}
