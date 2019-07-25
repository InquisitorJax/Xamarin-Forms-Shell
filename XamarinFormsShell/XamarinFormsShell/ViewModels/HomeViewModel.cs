using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinFormsShell.Models;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		public HomeViewModel()
		{
			NavigateToItemPageCommand = new DelegateCommand(NavigateToItemPage);
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

		private string _title;

		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}


		public ObservableCollection<Person> People { get; }

		public DelegateCommand NavigateToItemPageCommand { get; private set; }
	}
}
