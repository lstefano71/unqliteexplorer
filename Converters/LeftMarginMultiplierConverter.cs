using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UnQLiteExplorer.Converters
{
    public class LeftMarginMultiplierConverter : IValueConverter
    {
        public Double Length { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is TreeViewItem))
            {
                return Constants.ZeroThickness;
            }

            TreeViewItem item = value as TreeViewItem;
            if (item == null)
            {
                return Constants.ZeroThickness;
            }

            return new Thickness(Length * item.GetDepth(), 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
