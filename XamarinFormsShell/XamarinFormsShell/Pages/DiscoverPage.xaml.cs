using Xamarin.Forms.Xaml;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiscoverPage : MvvmContentPage
	{
		public DiscoverPage ()
		{
			InitializeComponent ();
		}

		protected override string NavigationRoute => NavigationRoutes.DiscoverPage;
	}
}