using Prism.Commands;
using System;

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
			Navigation.ItemPage("123");
		}

		public DelegateCommand NavigateToItemPageCommand { get; private set; }
	}
}
