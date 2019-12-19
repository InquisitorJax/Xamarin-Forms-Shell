namespace XamarinFormsShell.ViewModels
{
	public class DiscoverViewModel : ViewModelBase
	{
		public DiscoverViewModel()
		{
			_showNavBars = true;
		}

		private bool _showNavBars;

		public bool ShowNavBars
		{
			get { return _showNavBars; }
			set { SetProperty(ref _showNavBars, value); }
		}
	}
}
