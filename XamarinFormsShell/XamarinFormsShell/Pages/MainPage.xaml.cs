using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.Pages
{
	public partial class MainPage : MvvmContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			App.Navigation.Initialize(this);
		}

		protected override string NavigationRoute => NavigationRoutes.MainPage;
	}
}
