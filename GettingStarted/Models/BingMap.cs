using Microsoft.Maps.MapControl.WPF;

namespace Przewodnik.Models
{
    public class BingMap
    {
        private Location _centerLocation;
        public Location CenterLocation
        {
            get { return this._centerLocation; }
            set
            {
                this._centerLocation = value;
                return;
            }
        }
    }
}
