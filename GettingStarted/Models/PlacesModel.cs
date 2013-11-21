namespace Przewodnik.Models
{
    public class PlacesModel
    {
        public string Category { get; set; }
        public string NameOfPlace { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
       
        public PlacesModel()
        {
            Category = string.Empty;
            NameOfPlace = string.Empty;
            Latitude = 0.0;
            Longtitude = 0.0;
        }

        public PlacesModel(string category, string nameOfPlace, double longtitude, double latitude)
        {
            Category = category;
            NameOfPlace = nameOfPlace;
            Longtitude = longtitude;
            Latitude = latitude;
        }
    }
}
