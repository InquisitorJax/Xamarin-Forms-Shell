﻿
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace XamarinFormsShell.Droid
{
	[Activity(Label = "XamarinFormsShell", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "AppTheme_Experimental");

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			Xamarin.Forms.Svg.Droid.SvgImage.Init(this);

			LoadApplication(new App());
		}
	}
}