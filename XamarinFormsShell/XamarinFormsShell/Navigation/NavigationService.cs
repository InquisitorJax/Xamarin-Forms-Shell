using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsShell.Pages;

namespace XamarinFormsShell.Navigation
{
	public interface INavigationService
	{
		void ItemPage(string itemID);

		void Initialize(NavigableElement navigationRootPage);

		Task GoBackAsync(bool fromModal = false);
	}

	public class NavigationService : INavigationService
	{
		private bool _initialized;
		//NOTE: these string should match what's been defined in the AppShell.xaml
		private const string ROUTE_SCHEME = "app";
		private const string ROUTE_HOST = "wibcilabs.com";
		private const string ROUTE_BASE = "shellapp";

		private const string ROUTE_MARKER = "[ROUTE]";
		private string _shellNavTemplate = $"{ROUTE_SCHEME}://{ROUTE_HOST}/{ROUTE_BASE}/{ROUTE_MARKER}";

		private NavigableElement _navigationRoot;

		private AppShell _shell => App.Current.MainPage as AppShell;

		private NavigableElement NavigationRoot
		{
			get => GetShellSection(_navigationRoot) ?? _navigationRoot;
			set => _navigationRoot = value;
		}

		private void Shell_Navigated(object sender, ShellNavigatedEventArgs e)
		{
			Debug.WriteLine($"Navigated to {e.Current.Location} from {e.Previous?.Location} navigation type{e.Source.ToString()}");
		}

		private void Shell_Navigating(object sender, ShellNavigatingEventArgs e)
		{
			//TODO: Hook e.Cancel into viewmodel			
		}

		public void ItemPage(string id)
		{
			string route = _shellNavTemplate.Replace(ROUTE_MARKER, NavigationRoutes.ItemPage);
			route += $"?{NavigationParameters.Id}={id}";

			Debug.WriteLine($"Navigating to {route}");

			_shell.GoToAsync(route);
		}

		public async Task GoBackAsync(bool fromModal = false)
		{
			if (!fromModal)
			{
				await NavigationRoot.Navigation.PopAsync();
			}
			else
			{
				await NavigationRoot.Navigation.PopModalAsync();
			}
		}

		internal async Task NavigateToAsync(string navigationRoute, Dictionary<string, string> args = null, NavigationOptions options = null)
		{

			IView view = App.IoC.Resolve<IView>(navigationRoute);
			var page = view as Page;

			if (page == null)
			{
				Debug.WriteLine($"Could not resolve view for {navigationRoute}. Make sure it's registered with IoC");
				return;
			}

			options = options ?? NavigationOptions.Default();

			if (options.CloseFlyout)
			{
				await _shell.CloseFlyoutAsync();
			}

			if (options.ForgetCurrentPage)
			{
				var currentPage = NavigationRoot.Navigation.NavigationStack.LastOrDefault();
				NavigationRoot.Navigation.InsertPageBefore((Page)view, currentPage);
			}

			if (!options.Modal)
			{
				await NavigationRoot.Navigation.PushAsync(page, options.Animated).ConfigureAwait(false);
			}
			else
			{
				await NavigationRoot.Navigation.PushModalAsync(page, options.Animated).ConfigureAwait(false);
			}
		}

		public void Initialize(NavigableElement navigationRootPage)
		{
			if (_initialized)
			{
				return;
			}

			_initialized = true;
			NavigationRoot = navigationRootPage;
			_shell.Navigating += Shell_Navigating;
			_shell.Navigated += Shell_Navigated;
		}

		// Provides a navigatable section for elements which aren't explicitly defined within the Shell. For example,
		// if it's accessed from the fly-out through a MenuItem but it doesn't belong to any section
		internal static ShellSection GetShellSection(Element element)
		{
			if (element == null)
			{
				return null;
			}

			var parent = element;
			var parentSection = parent as ShellSection;

			while (parentSection == null && parent != null)
			{
				parent = parent.Parent;
				parentSection = parent as ShellSection;
			}

			return parentSection;
		}


		private async Task NavigateAsync(string navigationRoute, bool modal = false)
		{
			await _shell.CloseFlyoutAsync();
		}
	}
}
