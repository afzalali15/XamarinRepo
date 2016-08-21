using System;
using System.Threading.Tasks;

namespace Employee.PCL
{
	public class WebService
	{
		public static async Task<bool> AuthenticateAsync(string username, string password)
		{
			await Task.Delay(2000);
			if (username.Equals("asdf") && password.Equals("asdf"))
				return true;
			return false;
		}
	}
}

