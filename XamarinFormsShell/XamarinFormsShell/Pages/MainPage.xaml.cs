using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.Pages
{
	public partial class MainPage : MvvmContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override string NavigationRoute => NavigationRoutes.MainPage;
	}
}
