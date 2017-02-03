// **********************************
// FileName : ParticipantsPage.xaml.cs
// Author : Afzal Ali
// DateCreated : 31-01-2017
// Description : 
// **********************************
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SSListViewDemo
{
	public partial class ParticipantsPage : ContentPage
	{
		ParticipantsViewModel _viewModel;
		public ParticipantsPage()
		{
			InitializeComponent();

			//Create and bind context
			_viewModel = new ParticipantsViewModel();
			this.BindingContext = _viewModel;
			lstParticipant.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "Participants");

			//Set sort button in toolbar
			ToolbarItems.Add(new ToolbarItem("Sort", "sort", HandleAction));
		}

		async void HandleAction()
		{
			var result = await DisplayActionSheet("Sort By", "Ok", "Cancel", "Score", "Time");
			switch (result)
			{
				case "Score":
					_viewModel.SortParticipants("score");
					break;
				case "Time":
					_viewModel.SortParticipants("date");
					break;
				default:
					break;
			}
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var item = e.Item as Participant;
			if (item == null)
				return;

			(sender as ListView).SelectedItem = null;
		}

		protected override void OnParentSet()
		{
			base.OnParentSet();
			_viewModel.FetchParticipantsCommand.Execute(null);
		}
	}
}
