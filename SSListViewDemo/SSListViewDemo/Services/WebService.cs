// **********************************
// FileName : WebService.cs
// Author : Afzal Ali
// DateCreated : 31-01-2017
// Description : 
// **********************************
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SSListViewDemo
{
	public class WebService
	{
		/// <summary>
		/// Gets the List<data> async.
		/// </summary>
		/// <returns>The List<data> async.</returns>
		/// <param name="serviceName">Service name.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static async Task<Tuple<List<T>, string>> GetDataAsync<T>(string serviceName)
		{
			try
			{
				string uri = $"https://workat.getcloudcherry.com/api/{serviceName}";

				using (var client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(uri);
					if (!response.IsSuccessStatusCode)
						return new Tuple<List<T>, string>(null, response.StatusCode.ToString());

					var result = await response.Content.ReadAsStringAsync();
					var output = JsonConvert.DeserializeObject<List<T>>(result.ToString());
					return new Tuple<List<T>, string>(output, "");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return new Tuple<List<T>, string>(null, ex.Message);
			}
		}

	}
}
