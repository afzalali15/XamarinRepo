using System;
using Android.App;
using Android.Widget;
using DialogTest.Portable;

namespace DialogTest
{
	public class DialogProvider : IDialogProvider
	{
		static ProgressDialog progressDialog;

		public void ShowDialog(string title, string message)
		{
			var context = BaseActivity.Current;

			var dialog = new Android.App.AlertDialog.Builder(context);
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

		public void ShowToast(string message, ToastDuration duration = ToastDuration.Short)
		{
			var context = BaseActivity.Current;
			switch (duration)
			{
				case ToastDuration.Short:
					Toast.MakeText(context, message, ToastLength.Short).Show();
					break;
				case ToastDuration.Long:
					Toast.MakeText(context, message, ToastLength.Long).Show();
					break;
				default:
					Toast.MakeText(context,message,ToastLength.Short).Show();
					break;
			}
		}
	}


	public class CrossDialogProvider
	{
		static Lazy<IDialogProvider> TTS = new Lazy<IDialogProvider>(() => CreateDialog(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		/// <summary>
		/// Current settings to use
		/// </summary>
		public static IDialogProvider Instance
		{
			get
			{
				var ret = TTS.Value;
				if (ret == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

		static IDialogProvider CreateDialog()
		{
			return new DialogProvider();
		}

		static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the Xam.Plugins.Vibrate NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}

