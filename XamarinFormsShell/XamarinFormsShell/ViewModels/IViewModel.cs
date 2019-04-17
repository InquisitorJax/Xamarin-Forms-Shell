using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinFormsShell.ViewModels
{
	public interface IViewModel
	{
		Task InitializeAsync(Dictionary<string, string> args);		
	}
}
