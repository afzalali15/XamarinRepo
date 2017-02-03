// **********************************
// FileName : DialogService.cs
// Author : Afzal Ali
// DateCreated : 31-01-2017
// Description : 
// **********************************
using System;
using Acr.UserDialogs;

namespace SSListViewDemo
{
	public static class DialogService
	{
		public static void ShowLoading(string msg)
		{
			UserDialogs.Instance.ShowLoading(msg);
		}

		public static void HideLoading()
		{
			UserDialogs.Instance.HideLoading();
		}

		public static void ShowAlert(string msg, string title = "Alert", string okText = "Ok")
		{
			UserDialogs.Instance.Alert(msg, title, okText);
		}

	}
}
