using System.Windows;
using System.Windows.Data;

namespace Przewodnik.Converters
{
    public class NegativeConverter : IValueConverter
    {
        #region IValueConverter Members
        public static NegativeConverter Instance
        {
            get { return new NegativeConverter(); }
        }
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
                return -1.0 * (double)value;

            else
                throw new System.ArgumentException();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}