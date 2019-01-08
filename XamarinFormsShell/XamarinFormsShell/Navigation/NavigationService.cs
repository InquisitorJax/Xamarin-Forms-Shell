using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsShell.Pages;

namespace XamarinFormsShell.Navigation
{
	public interface INavigationService
	{
		void ItemPage(string itemID);
	}

	public class NavigationService : INavigationService
	{
		//NOTE: these string should match what's been defined in the AppShell.xaml
		private const string ROUTE_SCHEME = "app";
		private const string ROUTE_HOST = "wibcilabs.com";
		private const string ROUTE_BASE = "shellapp";

		private string _navTemplate = $"{ROUTE_SCHEME}://{ROUTE_HOST}/{ROUTE_BASE}/{0}";

		public NavigationService()
		{
			RegisterDynamicPageRoutes();
		}

		public void ItemPage(string itemID)
		{
			string route = string.Format(_navTemplate, NavigationRoutes.ItemPage);
			route += $"?itemID={itemID}";
			(App.Current.MainPage as Shell).GoToAsync(route);
		}

		private void RegisterDynamicPageRoutes()
		{
			Routing.RegisterRoute(NavigationRoutes.ItemPage, typeof(ItemPage));
		}
	}
}
