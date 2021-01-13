using Prism.Commands;
using System;
using System.Windows.Input;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class LoginOptionsViewModel : ViewModelBase
	{

		public LoginOptionsViewModel()
		{
			SelectOptionCommand = new DelegateCommand(SelectOption);
			BackToLoginCommand = new DelegateCommand(GoBackToLogin);
		}


		public ICommand SelectOptionCommand { get; }

		public ICommand BackToLoginCommand { get; }

		private string _username;

		public string Username
		{
			get { return _username; }
			set { SetProperty(ref _username, value); }
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		private void SelectOption()
		{
			Navigation.GoBackAsync(popToRoot: true);
		}

		private void GoBackToLogin()
		{
			Navigation.GoBackAsync();
		}
	}
}
