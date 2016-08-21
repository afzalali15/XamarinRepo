
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Employee.Droid
{
	[Activity(Label = "BaseActivity")]
	public class BaseActivity : AppCompatActivity
	{
		public static BaseActivity Current;
		public BaseActivity()
		{
			Current = this;
		}

		protected override void OnResume()
		{
			Current = this;
			base.OnResume();
		}
	}
}

