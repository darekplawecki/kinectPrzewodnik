using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Przewodnik.Utilities.Twitter
{
    class TwitterFollowers
    {
        public static string GetFollowerName(long id)
        {
            switch (id)
            {
                case 162477349:
                    return "wroclaw_info";
                case 85552998:
                    return "gaz_wroclawska";
                case 236324537:
                    return "gazeta_wroclaw";
                case 314167013:
                    return "TheWroclawInter";
                case 484679516:
                    return "StadionWroclaw";
                case 296212741:
                    return "AlertMPK";
                case 1424031918:
                    return "FaktyTVPWroclaw";
                default:
                    return "WrocławPrzewodnik";
            }
        }

        public static string GetFollowerImage(long id)
        {
            return "../Content/Twitter/" + GetFollowerName(id) + ".jpg";
        }

        public static List<SolidColorBrush> GetFollowerColors(long id)
        {
            switch (id)
            {
                case 162477349:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["BlueColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightBlueColor"] as SolidColorBrush 
                    };
                case 85552998:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["GreenColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightGreenColor"] as SolidColorBrush 
                    };
                case 236324537:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["OrangeColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightOrangeColor"] as SolidColorBrush 
                    };
                case 314167013:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["PurpleColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightPurpleColor"] as SolidColorBrush 
                    };
                case 484679516:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["LimeColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightLimeColor"] as SolidColorBrush 
                    };
                case 296212741:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["RedColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightRedColor"] as SolidColorBrush
                    };
                case 1424031918:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["YellowColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightYellowColor"] as SolidColorBrush 
                    };
                default:
                    return new List<SolidColorBrush>() 
                    { 
                        Application.Current.Resources["BlueColor"] as SolidColorBrush, 
                        Application.Current.Resources["LightBlueColor"] as SolidColorBrush 
                    };

            }
        }
    }
}