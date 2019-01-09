using Splat;

namespace XamarinFormsShell.Core
{
	public interface IDependencyResolver
	{
		T Resolve<T>(string key = null);
	}

	public class SplatDependencyResolver : IDependencyResolver
	{
		public T Resolve<T>(string key = null)
		{
			return Locator.Current.GetService<T>(key);
		}
	}
}
