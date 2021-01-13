using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using XamarinFormsShell.Models;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		public HomeViewModel()
		{
			NavigateToItemPageCommand = new DelegateCommand(NavigateToItemPage);
			NavigateToLoginCommand = new DelegateCommand(NavigateToLoginPage);
			Title = "Home Page";

			People = new ObservableCollection<Person>
			{
				new Person {Name = "Person 1"},
				new Person {Name = "Person 2"},
			};
		}

		private void NavigateToItemPage()
		{
			string id = "123";
			var args = new Dictionary<string, string>
			{
				{  NavigationParameters.Id, id }
			};

			Navigation.NavigateToAsync(NavigationRoutes.ItemPage, args);
		}

		private void NavigateToLoginPage()
		{
			Navigation.NavigateToAsync(NavigationRoutes.LoginPage, options: new NavigationOptions(modal: true));
		}

		private string _title;

		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}


		public ObservableCollection<Person> People { get; }

		public ICommand NavigateToItemPageCommand { get; private set; }
		public ICommand NavigateToLoginCommand { get; private set; }
	}
}
