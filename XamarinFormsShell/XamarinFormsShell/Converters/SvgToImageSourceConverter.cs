using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Svg;

namespace XamarinFormsShell.Converters
{
	public class SvgToImageSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}

			string imageName = $"Resources.{value.ToString()}";
			return SvgImageSource.FromSvgResource(imageName);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
