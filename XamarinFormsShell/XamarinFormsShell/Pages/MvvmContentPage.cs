using System.Collections.Generic;
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

		public Dictionary<string, string> NavigationArgs { get; set; }

		public IViewModel ViewModel { get; }

		protected abstract string NavigationRoute { get; }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModel.InitializeAsync(NavigationArgs);
		}

	}
}
