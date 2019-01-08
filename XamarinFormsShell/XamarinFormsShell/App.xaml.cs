using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsShell.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormsShell
{
	public partial class App : Application
	{
		private static INavigationService _navigation;
		public App()
		{
			_navigation = new NavigationService();			
			InitializeComponent();

			MainPage = new AppShell();
		}

		public static INavigationService Navigation => _navigation;

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
