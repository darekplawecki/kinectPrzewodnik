using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;

namespace Przewodnik.Models
{
    public class AttractionModel
    {
        public static String RYNEK_TITLE= "Rynek";
        public static String OSTROW_TUMSKI_TITLE = "Ostrów Tumski";
        public static String HALA_STULECIA_TITLE = "Hala Stulecia";
        public static String PALAC_KROLEWSKI_TITLE = "Pałac Królewski";
        public static String PANORAMA_RACLAWICKA_TITLE = "Panorama Racławicka";
        public static String OGROD_JAPONSKI_TITLE = "Ogród Japoński";
        public static String FONTANNA_TITLE = "Fontanna multimedialna";
        public static String WYSPA_SLODOWA_TITLE = "Wyspa Słodowa";
        public static String ZOO_TITLE = "ZOO";
        public static String OGROD_BOTANICZNY_TITLE = "Ogród Botaniczny";
        
        public string description;
        public List<string> photos;

        public AttractionModel()
        {
        }

        public String getTitleFor(String parameter)
        {

            switch (parameter)
            {
                case "Rynek":
                    return RYNEK_TITLE;
                case "OstrówTumski":
                    return OSTROW_TUMSKI_TITLE;
                case "HalaStulecia":
                    return HALA_STULECIA_TITLE;
                case "PałacKrólewski":
                    return PALAC_KROLEWSKI_TITLE;
                case "PanoramaRacławicka":
                    return PANORAMA_RACLAWICKA_TITLE;
                case "OgródJapoński":
                    return OGROD_JAPONSKI_TITLE;
                case "FontannaMultimedialna":
                    return FONTANNA_TITLE;
                case "WyspaSłodowa":
                    return WYSPA_SLODOWA_TITLE;
                case "ZOO":
                    return ZOO_TITLE;
                case "OgródBotaniczny":
                    return OGROD_BOTANICZNY_TITLE;
                default:
                    return "smuteczek :( ";
            }

        }
    }
}
