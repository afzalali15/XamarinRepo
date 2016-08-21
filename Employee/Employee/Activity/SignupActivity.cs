
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Employee.Droid
{
	[Activity(Label = "SignupActivity")]
	public class SignupActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.signup_activity);

			SetupUserInterface();
			SetupEventHandlers();
		}


		void SetupUserInterface()
		{

		}

		void SetupEventHandlers()
		{
		}
	}
}

