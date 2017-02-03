// **********************************
// FileName : Participant.cs
// Author : Afzal Ali
// DateCreated : 31-01-2017
// Description : 
// **********************************
using System;
namespace SSListViewDemo
{
	public class Participant
	{
		public string time { get; set; }
		public int score { get; set; }
		public string comment { get; set; }
		public string handle { get; set; }

		public DateTime _DateTime
		{
			get { return DateTime.ParseExact(time, "yyyy-MM-ddTHH:mm:ss.fffffffZ", System.Globalization.CultureInfo.InvariantCulture); }
		}
	}
}
