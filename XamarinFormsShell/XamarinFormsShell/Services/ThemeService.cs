using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinFormsShell.Resources;

namespace XamarinFormsShell.Services
{
	public interface IThemeService
	{
		void ApplyTheme(OSAppTheme theme);
	}

	public class ThemeService : IThemeService
	{


		public void ApplyTheme(OSAppTheme theme)
		{
			Application.Current.UserAppTheme = theme;

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            var dictionaryList = mergedDictionaries.ToList();
			foreach (var dictionary in dictionaryList)
			{
                if (dictionary is DarkTheme || dictionary is LightTheme)
				{
                    mergedDictionaries.Remove(dictionary);
				}
			}

            if (mergedDictionaries != null)
            {
                switch (theme)
                {
                    case OSAppTheme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case OSAppTheme.Light:
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }
	}
}
