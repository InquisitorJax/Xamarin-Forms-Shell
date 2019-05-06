using Prism.Commands;
using System.Collections.Generic;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		public HomeViewModel()
		{
			NavigateToItemPageCommand = new DelegateCommand(NavigateToItemPage);
			Title = "Home Page";
		}

		public string HomeIconName => "home.svg";

		private void NavigateToItemPage()
		{
			string id = "123";
			var args = new Dictionary<string, string>
			{
				{  NavigationParameters.Id, id }
			};

			Navigation.NavigateToAsync(NavigationRoutes.ItemPage, args);
		}

		private string _title;

		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public DelegateCommand NavigateToItemPageCommand { get; private set; }
	}
}
