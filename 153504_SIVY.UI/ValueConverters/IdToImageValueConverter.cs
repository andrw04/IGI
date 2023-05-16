using _153504_SIVY.Domain.Entities;
using System.Globalization;

namespace _153504_SIVY.UI.ValueConverters
{
    public class IdToImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fileName = ((long)value).ToString() + ".png";

            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
            if (!File.Exists(filePath))
            {
                return "default.png";
            }

            return filePath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
