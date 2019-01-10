using Splat;
using System.Diagnostics;

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
			var instance = Locator.Current.GetService<T>(key);

			if (instance == null)
			{
				Debug.WriteLine($"Could not resolve {typeof(T).Name} for {key}");
			}

			return instance;
		}
	}
}
