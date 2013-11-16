using Microsoft.Maps.MapControl.WPF;
using Przewodnik.Models;
using Przewodnik.ViewModels;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Przewodnik.Utilities.DataLoader
{
    public class MapLoader
    {
        private static MapLoader _instance;
        public static MapLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MapLoader();
                }
                return _instance;
            }
        }


        BingMap _bingMap;
        Location _startLocation = new Location(51.109521, 17.046638);

        public MapLoader()
        {
            _bingMap = new BingMap();
            _bingMap.CenterLocation = _startLocation;
        }

        public BingMap BingMap
        {
            get { return _bingMap; }
        }

        public Location StartLocation
        {
            get { return _startLocation; }
        }

    }
}
