﻿namespace XamarinFormsShell.Navigation
{
	public class NavigationOptions
	{
		public NavigationOptions(bool modal = false, bool closeFlyout = true, bool animated = true)
		{
			CloseFlyout = closeFlyout;
			Modal = modal;
			Animated = animated;
		}

		public bool CloseFlyout { get; }

		public bool Modal { get; }

		public bool Animated { get; set; }

		public static NavigationOptions Default()
		{
			return new NavigationOptions();
		}
	}
}
