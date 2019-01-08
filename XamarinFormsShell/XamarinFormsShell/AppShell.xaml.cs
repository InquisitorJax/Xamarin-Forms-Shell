using Xamarin.Forms.Xaml;

namespace XamarinFormsShell
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
		}
	}
}