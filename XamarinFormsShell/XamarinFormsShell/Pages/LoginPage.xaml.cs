using Xamarin.Forms.Xaml;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : MvvmContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		protected override string NavigationRoute => NavigationRoutes.LoginPage;
	}
}