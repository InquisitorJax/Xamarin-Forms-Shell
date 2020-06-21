using Xamarin.Forms;
using XamarinFormsShell.Services;

namespace XamarinFormsShell.ViewModels
{
	public class DiscoverViewModel : ViewModelBase
	{

		public DiscoverViewModel()
		{
			_showNavBars = true;
		}

		private bool _showNavBars;

		public bool ShowNavBars
		{
			get { return _showNavBars; }
			set { SetProperty(ref _showNavBars, value); }
		}

		private bool _showDarkTheme;

		public bool ShowDarkTheme
		{
			get { return _showDarkTheme; }
			set 
			{
				SetProperty(ref _showDarkTheme, value);
				ToggleTheme();
			}
		}

		private void ToggleTheme()
		{
			var themeService = App.IoC.Resolve<IThemeService>();
			var theme = ShowDarkTheme ? OSAppTheme.Dark : OSAppTheme.Light;
			themeService.ApplyTheme(theme);
		}

	}
}
