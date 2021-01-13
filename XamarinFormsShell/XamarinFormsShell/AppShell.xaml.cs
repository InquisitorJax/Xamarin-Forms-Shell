using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsShell.Navigation;
using XamarinFormsShell.Pages;

namespace XamarinFormsShell
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppShell : Shell
	{
		public static readonly TimeSpan TimeFlyoutCloses = TimeSpan.FromSeconds(0.5f);

		public AppShell()
		{

			BindingContext = new AppShellViewModel();
			InitializeComponent();

			Routing.RegisterRoute(NavigationRoutes.LoginPage, typeof(LoginPage));
		}

		internal async Task CloseFlyoutAsync()
		{
			FlyoutIsPresented = false;
			await Task.Delay(TimeFlyoutCloses);
		}

	}
}