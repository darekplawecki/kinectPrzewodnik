using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Controls
{
    class DesignResources
    {
        double width;
        double height;

        public DesignResources()
        {
            width = SystemParameters.PrimaryScreenWidth;
            height = SystemParameters.PrimaryScreenHeight;
        }

        public void AdjustResolution()
        {
            double ico_size = ConvertSize(86);

            Application.Current.Resources["Size18"] = ConvertSize(18);
            Application.Current.Resources["Size24"] = ConvertSize(24);
            Application.Current.Resources["Size28"] = ConvertSize(28);
            Application.Current.Resources["Size32"] = ConvertSize(32);
            Application.Current.Resources["Size36"] = ConvertSize(36);
            Application.Current.Resources["Size45"] = ConvertSize(45);
            Application.Current.Resources["Size50"] = ConvertSize(50);
            Application.Current.Resources["Size55"] = ConvertSize(55);
            Application.Current.Resources["Size60"] = ConvertSize(60);
            Application.Current.Resources["Size72"] = ConvertSize(72);
            Application.Current.Resources["Size80"] = ConvertSize(80);
            Application.Current.Resources["Size90"] = ConvertSize(90);
            Application.Current.Resources["Size150"] = ConvertSize(150);

            Style style = new Style { TargetType = typeof(Image) };
            style.Setters.Add(new Setter(Image.WidthProperty, ico_size));
            style.Setters.Add(new Setter(Image.HeightProperty, ico_size));
            Application.Current.Resources["Icon"] = style;

            style = new Style { TargetType = typeof(Image) };
            style.Setters.Add(new Setter(Image.WidthProperty, ConvertSize(110)));
            style.Setters.Add(new Setter(Image.HeightProperty, ConvertSize(93)));
            Application.Current.Resources["WeatherIcon"] = style;

            Application.Current.Resources["BlockMargin"] = new Thickness(0.02315 * height);
            Application.Current.Resources["BlockWeatherMargin"] = new Thickness { Left = ConvertSize(20), Bottom = ConvertSize(10), Right = ConvertSize(20), Top = ConvertSize(10) };
            Application.Current.Resources["BlockWeatherMargin2"] = new Thickness { Left = ConvertSize(15), Bottom = ConvertSize(15), Right = ConvertSize(15), Top = ConvertSize(15) };
            Application.Current.Resources["BlockTwitterMargin"] = new Thickness { Left = 0.02315 * height, Bottom = 0.01389 * height, Right = 0.02315 * height, Top = 0.01389 * height };
            Application.Current.Resources["TextTopMargin"] = new Thickness { Left = 0, Bottom = 0, Right = 0, Top = 0.01150 * height };
            Application.Current.Resources["TextBottomMargin"] = new Thickness { Left = 0, Bottom = 0.01150 * height, Right = 0, Top = 0 };
            Application.Current.Resources["TextTopBottomMargin"] = new Thickness { Left = 0, Bottom = 0.02 * height, Right = 0, Top = 0.02 * height };
            Application.Current.Resources["TextTopBottomMarginSmaller"] = new Thickness { Left = 0, Bottom = 0.01150 * height, Right = 0, Top = 0.01150 * height };
            Application.Current.Resources["EventIconTopMargin"] = new Thickness { Left = 0, Bottom = 0, Right = 0, Top = 0.03041 * height }; // 35
            Application.Current.Resources["LoaderTopMargin"] = new Thickness { Left = 0, Bottom = 0, Right = 0, Top = ConvertSize(90) };

            style = new Style { TargetType = typeof(TextBlock) };
            style.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Light));
            style.Setters.Add(new Setter(TextBlock.ForegroundProperty, Application.Current.Resources["GrayColor"]));
            style.Setters.Add(new Setter(TextBlock.MarginProperty, new Thickness { Left = 0.11574 * height, Top = 0.04167 * height, Bottom = 0, Right = 0 }));

            Application.Current.Resources["PageTitle"] = style;
            Application.Current.Resources["AttractionBlockSize"] = 0.31907 * height;
            Application.Current.Resources["EventCategoryBlockSize"] = ConvertSize(180);
            Application.Current.Resources["EventCalendarBlockSize"] = ConvertSize(210);
            Application.Current.Resources["EventBlockSize"] = ConvertSize(1180);
            Application.Current.Resources["EventIconSize"] = ConvertSize(113);
            Application.Current.Resources["BackButtonSize"] = ConvertSize(252);
            Application.Current.Resources["LoaderLogoWidth"] = ConvertSize(532);
            Application.Current.Resources["LoaderWidth"] = ConvertSize(677);
            Application.Current.Resources["LoaderHeight"] = ConvertSize(52);
            Application.Current.Resources["TweetHeight"] = new GridLength(0.15741 * height);
            Application.Current.Resources["TweetWidth"] = new GridLength(0.52083 * width);
            Application.Current.Resources["WeatherAreaWidth"] = ConvertSize(265);
            Application.Current.Resources["WeatherAreaHeight"] = ConvertSize(165);
            Application.Current.Resources["SnapshootIconSize"] = ConvertSize(168);
            Application.Current.Resources["NavButtonsIconSize"] = ConvertSize(125);

        }

        private double ConvertSize(int size)
        {
            return (size / 1080.0) * height;
        }


    }
}
