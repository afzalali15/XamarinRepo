using System;
namespace Employee.PCL
{
	public interface IDialogProvider
	{
		/// <summary>
		/// Shows Alert Dialog
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="message">Message.</param>
		void ShowDialog(string title, string message);

		/// <summary>
		/// Shows Loading Dialog
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="message">Message.</param>
		/// <param name="cancelable">Cancelable, Default value is true</param>
		void ShowLoading(string title, string message, bool cancelable = true);

		/// <summary>
		/// Hides current loading dialog
		/// </summary>
		void HideLoading();


		//void ShowAlertDialog();
		//void ShowWarningDialog();
		//void ShowToast();
		//void ShowSnackBar();
	}
}

