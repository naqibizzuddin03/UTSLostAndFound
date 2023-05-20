namespace UTSLostAndFound.Converter
{
    public class BytesToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is byte[] bytes)
            {
                return ImageSource.FromStream(() => new MemoryStream(bytes));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
