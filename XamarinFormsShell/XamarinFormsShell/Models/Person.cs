using Prism.Mvvm;
using System;

namespace XamarinFormsShell.Models
{
	public class Person : BindableBase
	{

		public Person()
		{
			_id = Guid.NewGuid().ToString();
		}

		private string _id;

		public string Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}


		private string _name;

		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

	}
}
