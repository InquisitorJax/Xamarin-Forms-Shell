using Prism.Commands;
using System.Windows.Input;

namespace XamarinFormsShell.ViewModels
{
	public class AboutViewModel : ViewModelBase
	{
		public AboutViewModel()
		{
			CloseCommand = new DelegateCommand(Close);
		}

		public ICommand CloseCommand { get; }

		private void Close()
		{
			Navigation.GoBackAsync(true);
		}

	}
}
