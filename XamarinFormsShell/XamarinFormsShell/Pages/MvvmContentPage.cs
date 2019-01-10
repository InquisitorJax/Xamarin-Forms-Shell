using Xamarin.Forms;
using XamarinFormsShell.ViewModels;

namespace XamarinFormsShell.Pages
{
	public abstract class MvvmContentPage : ContentPage, IView
	{

		public MvvmContentPage()
		{
			ViewModel = App.IoC.Resolve<IViewModel>(NavigationRoute);
			BindingContext = ViewModel;
		}

		public IViewModel ViewModel { get; private set; }

		protected abstract string NavigationRoute { get; }

		protected override void OnAppearing()
		{
			base.OnAppearing();

			ViewModel.InitializeAsync();
		}

	}
}
