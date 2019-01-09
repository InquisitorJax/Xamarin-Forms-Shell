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

	}
}
