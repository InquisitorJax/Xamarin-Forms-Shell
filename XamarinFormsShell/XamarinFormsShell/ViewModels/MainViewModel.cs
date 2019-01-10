using Prism.Commands;
using System;
using System.Collections.Generic;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			NavigateToItemPageCommand = new DelegateCommand(NavigateToItemPage);
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

		public DelegateCommand NavigateToItemPageCommand { get; private set; }
	}
}
