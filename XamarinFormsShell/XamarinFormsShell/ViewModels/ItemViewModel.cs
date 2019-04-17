using System.Collections.Generic;
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

		public override Task InitializeAsync(Dictionary<string, string> args)
		{
			if (args?.Count > 0 && args.ContainsKey(NavigationParameters.Id))
			{
				ItemId = args[NavigationParameters.Id] + "Detail Page";
			}

			return Task.CompletedTask;
		}

	}
}
