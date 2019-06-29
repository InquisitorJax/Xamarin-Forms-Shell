using System.Diagnostics;
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

		private void SwipeGestureRecognizer_Swiped(object sender, Xamarin.Forms.SwipedEventArgs e)
		{
			this.DisplayAlert("Swiped Event", "Swiped Left", null);
		}

		private void SwipeGestureRecognizer_Swiped_1(object sender, Xamarin.Forms.SwipedEventArgs e)
		{
			this.DisplayAlert("Swiped Right", "Swiped Right", null);
		}
	}
}
