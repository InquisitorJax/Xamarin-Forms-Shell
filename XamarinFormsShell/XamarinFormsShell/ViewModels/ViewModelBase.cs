using Prism.Mvvm;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsShell.Navigation;

namespace XamarinFormsShell.ViewModels
{
	public class ViewModelBase : BindableBase, IViewModel
	{
		public ViewModelBase()
		{
			NavigationArgs = new Dictionary<string, string>();
		}

		protected INavigationService Navigation => App.Navigation;

		public virtual Task InitializeAsync() => Task.CompletedTask;

		public Dictionary<string, string> NavigationArgs { get; set; }

	}
}
