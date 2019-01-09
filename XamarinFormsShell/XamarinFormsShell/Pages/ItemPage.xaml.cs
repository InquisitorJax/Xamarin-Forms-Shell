
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsShell.Navigation;
using XamarinFormsShell.ViewModels;

namespace XamarinFormsShell.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	[QueryProperty(nameof(IdParameter), NavigationParameters.Id)]
	public partial class ItemPage : MvvmContentPage
	{
		public ItemPage()
		{
			InitializeComponent();
		}

		private ItemViewModel MyViewModel => (ItemViewModel)ViewModel;

		public string IdParameter
		{
			get
			{
				return MyViewModel.ItemId;
			}
			set
			{
				MyViewModel.ItemId = value;
			}
		}

		protected override string NavigationRoute => NavigationRoutes.ItemPage;
	}
}