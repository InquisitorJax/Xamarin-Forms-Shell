using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsShell.Pages;

namespace XamarinFormsShell.Navigation
{
	public interface INavigationService
	{
		void Initialize(NavigableElement navigationRootPage);

		Task NavigateToAsync(string navigationRoute, Dictionary<string, string> args = null, NavigationOptions options = null);

		Task GoBackAsync(bool popToRoot = false);
	}

	public class NavigationService : INavigationService
	{
		// doc: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/navigation

		private bool _initialized;
		
		private NavigableElement _navigationRoot;

		private AppShell _shell => App.Current.MainPage as AppShell;
		private NavigationPage _modalNavigation;

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

		private async Task NavigateShellAsync(string navigationRoute, Dictionary<string, string> args, bool animated = true)
		{
			var queryString = args.AsQueryString();
			navigationRoute = navigationRoute + queryString;
			Debug.WriteLine($"Shell Navigating to {navigationRoute}");
			await _shell.GoToAsync(navigationRoute, animated);
		}

		public async Task GoBackAsync(bool popToRoot = false)
		{
			if (popToRoot)
			{
				await Shell.Current.Navigation.PopToRootAsync(false);
			}

			await Shell.Current.GoToAsync("..");
		}

		public async Task NavigateToAsync(string navigationRoute, Dictionary<string, string> args = null, NavigationOptions options = null)
		{
			IView view = App.IoC.Resolve<IView>(navigationRoute);
			var page = view as Page;

			options = options ?? NavigationOptions.Default();

			if (page == null)
			{
				Debug.WriteLine($"Could not resolve view for {navigationRoute}: Assuming this is a shell route...");
				await NavigateShellAsync(navigationRoute, args, options.Animated);
				return;
			}

			if (page is MvvmContentPage mvvmPage)
			{
				mvvmPage.NavigationArgs = args;
			}

			if (options.CloseFlyout)
			{
				await _shell.CloseFlyoutAsync();
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
	}
}
