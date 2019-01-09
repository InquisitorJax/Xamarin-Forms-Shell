using System;
using Splat;
using XamarinFormsShell.Pages;
using XamarinFormsShell.ViewModels;

namespace XamarinFormsShell.Core
{
	public interface IDependencyRegistry
	{
		void Register<TType, TInterface>(string key = null);

		void RegisterSingleton<TType, TInterface>(string key = null, bool lazy = false);
	}

	public class SplatDependencyRegistry : IDependencyRegistry
	{
		public void Register<TType, TInterface>(string key = null)
		{
			Locator.CurrentMutable.Register(() => Activator.CreateInstance<TType>(), typeof(TInterface), key);
		}

		public void RegisterSingleton<TType, TInterface>(string key = null, bool lazy = false)
		{
			if (!lazy)
			{
				Locator.CurrentMutable.RegisterConstant(Activator.CreateInstance<TType>(), typeof(TInterface), key);
			}
			else
			{
				Locator.CurrentMutable.RegisterLazySingleton(() => Activator.CreateInstance<TType>(), typeof(TInterface), key);
			}
		}

	}
}
