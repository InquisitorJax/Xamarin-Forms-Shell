using System;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace XamarinFormsShell
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public static readonly TimeSpan TimeFlyoutCloses = TimeSpan.FromSeconds(0.5f);

		public AppShell()
		{
			BindingContext = new AppShellViewModel();
			InitializeComponent();			
		}

		internal async Task CloseFlyoutAsync()
		{
			FlyoutIsPresented = false;
			await Task.Delay(TimeFlyoutCloses);
		}

	}
}