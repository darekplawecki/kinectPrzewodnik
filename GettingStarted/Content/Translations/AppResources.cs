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
    }
}
