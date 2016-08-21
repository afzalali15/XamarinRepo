
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DialogTest
{
	[Activity(Label = "BaseActivity")]
	public class BaseActivity : Activity
	{
		public static BaseActivity Current;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
		}

		protected override void OnResume()
		{
			Current = this;
			base.OnResume();
		}
	}
}

