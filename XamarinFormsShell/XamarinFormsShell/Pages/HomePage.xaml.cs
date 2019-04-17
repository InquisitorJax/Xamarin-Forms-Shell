using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.Pages
{
	public partial class HomePage : MvvmContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			App.Navigation.Initialize(this);
		}

		protected override string NavigationRoute => NavigationRoutes.HomePage;
	}
}
