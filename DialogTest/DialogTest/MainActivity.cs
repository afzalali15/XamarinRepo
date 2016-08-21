using Android.App;
using Android.Widget;
using Android.OS;

namespace DialogTest
{
	[Activity(Label = "DialogTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += delegate {
				//CrossDialogProvider.Instance.ShowDialog("Test","Testing dialog box");
				//CrossDialogProvider.Instance.ShowLoading("Authorizing..", "Please wait...", false);
				CrossDialogProvider.Instance.ShowToast("Awesome");
			};
		}
	}
}


