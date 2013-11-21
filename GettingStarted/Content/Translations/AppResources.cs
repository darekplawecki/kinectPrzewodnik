using System;
using System.Globalization;
using System.Windows;

namespace Przewodnik.Content.Traslations
{
    class AppResources
    {
        public static string GetText(string key)
        {
            CultureInfo cultureInfo = ((App)Application.Current).culture;
            return ((App)Application.Current).Rm.GetString(key, cultureInfo);
        }

        public static CultureInfo GetCultureInfo()
        {
            return ((App)Application.Current).culture;
        }

        public static void SetCultureInfo(string culture)
        {
            ((App)Application.Current).culture = new CultureInfo(culture);
        }
    }
}
