using System;
using Android.App;
using Employee.PCL;

namespace Employee.Droid
{
	public class DialogProvider : IDialogProvider
	{
		static ProgressDialog progressDialog;

		public void ShowDialog(string title, string message)
		{
			var context = BaseActivity.Current;

			var dialog = new Android.Support.V7.App.AlertDialog.Builder(context);
			dialog.SetTitle(title);
			dialog.SetMessage(message);
			dialog.SetPositiveButton("Ok", (sender, e) => { dialog.Dispose(); });
			dialog.Show();
		}

		public void ShowLoading(string title, string message, bool cancelable = true)
		{
			var context = BaseActivity.Current;

			progressDialog = new ProgressDialog(context);
			progressDialog.SetTitle(title);
			progressDialog.SetMessage(message);
			progressDialog.SetCancelable(cancelable);
			progressDialog.Show();
		}

		public void HideLoading()
		{
			if (progressDialog != null)
			{
				progressDialog.Hide();
				progressDialog.Dispose();
			}
		}
	}
}

