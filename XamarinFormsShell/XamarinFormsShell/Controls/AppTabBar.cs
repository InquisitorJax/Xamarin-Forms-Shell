using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinFormsShell.Controls
{
	public class AppTabBar : TabBar
	{
		protected override void OnTabIndexPropertyChanged(int oldValue, int newValue)
		{
			base.OnTabIndexPropertyChanged(oldValue, newValue);
			Debug.WriteLine("============> TAB BAR INDEX CHANGED!");
		}
	}
}
