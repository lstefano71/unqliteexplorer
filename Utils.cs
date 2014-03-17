using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UnQLiteExplorer
{
    internal static class Utils
    {
        public static ImageSource ImageSourceFromUri(String uri)
        {
            ImageSource src = null;
            if (!String.IsNullOrEmpty(uri))
            {
                src = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            }

            return src;
        }

        public static Style GetGenericStyle(String name)
        {
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri(@"Themes/Generic.xaml", UriKind.RelativeOrAbsolute);
            Style style = rd[name] as Style;
            return style;
        }

        public static String GetFileName(String fullName)
        {
            FileInfo fi = new FileInfo(fullName);
            return fi.Name;
        }
    }
}
