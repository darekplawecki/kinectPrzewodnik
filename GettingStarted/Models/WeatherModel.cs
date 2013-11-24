using System.ComponentModel;
namespace Przewodnik.Models
{
    public class WeatherModel : INotifyPropertyChanged
    {
        public string WeatherImage { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public string NameDay { get; set; }

        public int state;
        public int WeatherState
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("WeatherState");
            }
        }

        public WeatherModel()
        {
            WeatherImage = string.Empty;
            Temperature = string.Empty;
            Description = string.Empty;
            NameDay = string.Empty;
            WeatherState = 0;
        }

        public WeatherModel(string weatherImage, string temperature, string description, string nameDay)
        {
            this.WeatherImage = weatherImage;
            this.Temperature = temperature;
            this.Description = description;
            this.NameDay = nameDay;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
