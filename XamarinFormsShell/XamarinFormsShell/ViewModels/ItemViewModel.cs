using System.Threading.Tasks;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class ItemViewModel : ViewModelBase
	{
		private string _itemId;

		public string ItemId
		{
			get { return _itemId; }
			set { SetProperty(ref _itemId, value); }
		}

		public override Task InitializeAsync()
		{
			if (NavigationArgs?.Count > 0 && NavigationArgs.ContainsKey(NavigationParameters.Id))
			{
				ItemId = NavigationArgs[NavigationParameters.Id] + "Detail Page";
			}

			return Task.CompletedTask;
		}

	}
}
