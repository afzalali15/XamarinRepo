// **********************************
// FileName : ParticipantsViewModel.cs
// Author : Afzal Ali
// DateCreated : 31-01-2017
// Description : 
// **********************************
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using Plugin.Connectivity;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace SSListViewDemo
{
	public class ParticipantsViewModel : INotifyPropertyChanged
	{
		List<Participant> participants;
		Command fetchParticipantsCommand;

		public List<Participant> Participants
		{
			get { return participants; }
			set
			{
				participants = value;
				OnPropertyChanged("Participants");
			}
		}


		public Command FetchParticipantsCommand
		{
			get
			{
				return fetchParticipantsCommand ?? (fetchParticipantsCommand = new Command(
					async () => await ExecuteFetchParticipantsCommand()
				));
			}
		}

		public void SortParticipants(string key)
		{
			var tempParticipants = new List<Participant>();
			if (key == "score")
				tempParticipants = participants.OrderByDescending(p => p.score).ToList();
			//participants.Sort((x, y) => y.score.CompareTo(x.score));
			else if (key == "date")
				tempParticipants = participants.OrderByDescending(p => p._DateTime).ToList();
			//participants.Sort((x, y) => y._DateTime.CompareTo(x._DateTime));


			Participants = tempParticipants;
			//OnPropertyChanged("Participants");
		}

		/// <summary>
		/// Executes the fetch participants command.
		/// </summary>
		/// <returns>Task</returns>
		public async Task ExecuteFetchParticipantsCommand()
		{
			try
			{
				//Check connectivity and inform if not available
				if (!CrossConnectivity.Current.IsConnected)
				{
					DialogService.ShowAlert("No Internet Connectivity, Please try again!");
					return;
				}

				//Fetch participants from service
				//facing some issue with Userdialogs on iOS
				if (Device.OS == TargetPlatform.Android)
					DialogService.ShowLoading("Loading participants..");
				var output = await WebService.GetDataAsync<Participant>("buildsample");
				if (Device.OS == TargetPlatform.Android)
					DialogService.HideLoading();

				//If theres problem fetching participants show error msg
				if (output.Item1 == null)
				{
					DialogService.ShowAlert(output.Item2);
					return;
				}

				//else assing participants to list
				Participants = output.Item1;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
