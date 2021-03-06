﻿using System.Windows;
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
            Application.Current.Resources["Size40"] = ConvertSize(40);
            Application.Current.Resources["Size45"] = ConvertSize(45);
            Application.Current.Resources["Size50"] = ConvertSize(50);
            Application.Current.Resources["Size55"] = ConvertSize(55);
            Application.Current.Resources["Size60"] = ConvertSize(60);
            Application.Current.Resources["Size65"] = ConvertSize(65);
            Application.Current.Resources["Size72"] = ConvertSize(72);
            Application.Current.Resources["Size80"] = ConvertSize(80);
            Application.Current.Resources["Size90"] = ConvertSize(90);
            Application.Current.Resources["Size200"] = ConvertSize(200);

            Style style = new Style { TargetType = typeof(Image) };
            style.Setters.Add(new Setter(Image.WidthProperty, ico_size));
            style.Setters.Add(new Setter(Image.HeightProperty, ico_size));
            Application.Current.Resources["Icon"] = style;

            style = new Style { TargetType = typeof(Image) };
            style.Setters.Add(new Setter(Image.WidthProperty, ConvertSize(141)));
            style.Setters.Add(new Setter(Image.HeightProperty, ConvertSize(120)));
            Application.Current.Resources["WeatherIcon"] = style;

            Application.Current.Resources["BlockMargin"] = new Thickness(0.02315 * height);
            Application.Current.Resources["BlockMarginLeft"] = new Thickness(ConvertSize(40));
            Application.Current.Resources["BlockMarginBigger"] = new Thickness { Left = ConvertSize(40), Bottom = 0, Right = 0, Top = 0 };
            Application.Current.Resources["BlockWeatherMargin"] = new Thickness { Left = ConvertSize(15), Bottom = 0, Right = ConvertSize(15), Top = 0 };
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
            Application.Current.Resources["LoaderLogoWidth"] = ConvertSize(532);
            Application.Current.Resources["LoaderWidth"] = ConvertSize(677);
            Application.Current.Resources["LoaderHeight"] = ConvertSize(52);
            Application.Current.Resources["TweetHeight"] = new GridLength(0.15741 * height);
            Application.Current.Resources["TweetWidth"] = new GridLength(0.52083 * width);
            Application.Current.Resources["WeatherAreaWidth"] = ConvertSize(300);
            Application.Current.Resources["WeatherAreaHeight"] = ConvertSize(120);
            Application.Current.Resources["SnapshootIconSize"] = ConvertSize(168);
            Application.Current.Resources["NavButtonsIconSize"] = ConvertSize(125);
            Application.Current.Resources["CameraWidth"] = ConvertSize(1067);
            Application.Current.Resources["CameraHeight"] = ConvertSize(800);
            Application.Current.Resources["CodeQRAreaWidth"] = ConvertSize(1500);
            Application.Current.Resources["CodeQRAreaHeight"] = ConvertSize(560);
            Application.Current.Resources["PictureWidth"] = ConvertSize(640);
            Application.Current.Resources["PictureHeight"] = ConvertSize(480);
            Application.Current.Resources["QRSize"] = ConvertSize(315);
            Application.Current.Resources["CodeQRAreaWidthRight"] = ConvertSize(740);
            Application.Current.Resources["VideoProgressBackgroundWidth"] = ConvertSize(1788);
            Application.Current.Resources["VideoProgressBackgroundHeight"] = ConvertSize(90);
            Application.Current.Resources["VideoProgressHeight"] = ConvertSize(15);
            Application.Current.Resources["VideoButtonSize"] = ConvertSize(298);
            Application.Current.Resources["MicrophoneAreaHeight"] = ConvertSize(80);

        }

        private double ConvertSize(int size)
        {
            return (size / 1080.0) * height;
        }


    }
}
