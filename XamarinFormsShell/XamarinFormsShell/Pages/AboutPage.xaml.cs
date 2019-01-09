
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsShell.Navigation;
using XamarinFormsShell.ViewModels;

namespace XamarinFormsShell.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : MvvmContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
		}

		protected override string NavigationRoute => NavigationRoutes.AboutPage;
	}
}