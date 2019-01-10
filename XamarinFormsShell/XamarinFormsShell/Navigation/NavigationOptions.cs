namespace XamarinFormsShell.Navigation
{
	public class NavigationOptions
	{
		public NavigationOptions(bool modal = false, bool closeFlyout = true, bool animated = true, bool forgetCurrentPage = false)
		{
			CloseFlyout = closeFlyout;
			Modal = modal;
			Animated = animated;
			ForgetCurrentPage = forgetCurrentPage;
		}

		public bool CloseFlyout { get; }

		public bool Modal { get; }

		public bool Animated { get; set; }

		public bool ForgetCurrentPage { get; }

		public static NavigationOptions Default()
		{
			return new NavigationOptions();
		}
	}
}
