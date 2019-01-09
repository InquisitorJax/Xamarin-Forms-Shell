using Prism.Mvvm;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class ViewModelBase : BindableBase, IViewModel
	{

		protected INavigationService Navigation => App.Navigation;
	}
}
