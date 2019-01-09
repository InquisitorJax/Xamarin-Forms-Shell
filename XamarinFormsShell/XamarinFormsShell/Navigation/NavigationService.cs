using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using XamarinFormsShell.Pages;

namespace XamarinFormsShell.Navigation
{
	public interface INavigationService
	{
		void ItemPage(string itemID);

		void Initialize();
	}

	public class NavigationService : INavigationService
	{
		private bool _initialized;
		//NOTE: these string should match what's been defined in the AppShell.xaml
		private const string ROUTE_SCHEME = "app";
		private const string ROUTE_HOST = "wibcilabs.com";
		private const string ROUTE_BASE = "shellapp";

		private const string ROUTE_MARKER = "[ROUTE]";
		private string _navTemplate = $"{ROUTE_SCHEME}://{ROUTE_HOST}/{ROUTE_BASE}/{ROUTE_MARKER}";

		public NavigationService()
		{
			RegisterDynamicPageRoutes();
		}

		private void NavigationService_Navigated(object sender, ShellNavigatedEventArgs e)
		{
			Debug.WriteLine($"Navigated to {e.Current.Location} from {e.Previous?.Location} navigation type{e.Source.ToString()}");
		}

		private void NavigationService_Navigating(object sender, ShellNavigatingEventArgs e)
		{
			//TODO: Hook e.Cancel into viewmodel			
		}

		public void ItemPage(string id)
		{
			string route = _navTemplate.Replace(ROUTE_MARKER, NavigationRoutes.ItemPage);
			route += $"?{NavigationParameters.Id}={id}";

			Debug.WriteLine($"Navigating to {route}");

			(App.Current.MainPage as Shell).GoToAsync(route);
		}

		public void GoBack()
		{
			//TODO: Implement
		}

		private void RegisterDynamicPageRoutes()
		{
			Routing.RegisterRoute(NavigationRoutes.ItemPage, typeof(ItemPage));
		}

		public void Initialize()
		{
			if (_initialized)
			{
				return;
			}

			_initialized = true;
			(App.Current.MainPage as Shell).Navigating += NavigationService_Navigating;
			(App.Current.MainPage as Shell).Navigated += NavigationService_Navigated;
		}
	}
}
