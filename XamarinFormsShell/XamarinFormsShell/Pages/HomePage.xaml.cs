﻿using System.Collections.Generic;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.Pages
{
	public partial class HomePage : MvvmContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			var modalHosts = new List<string>
			{
				NavigationRoutes.LoginPage
			};

			App.Navigation.Initialize(this, modalHosts);
		}

		protected override string NavigationRoute => NavigationRoutes.HomePage;

		private void SwipeGestureRecognizer_Swiped(object sender, Xamarin.Forms.SwipedEventArgs e)
		{
			this.DisplayAlert("Swiped Event", "Swiped Left", null);
		}

		private void SwipeGestureRecognizer_Swiped_1(object sender, Xamarin.Forms.SwipedEventArgs e)
		{
			this.DisplayAlert("Swiped Right", "Swiped Right", "cancel");
		}
	}
}
