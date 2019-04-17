using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsShell.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomNavigationBar : ContentView
	{
		public CustomNavigationBar ()
		{
			InitializeComponent ();
		}
	}
}