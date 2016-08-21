using System;
using System.Diagnostics;

namespace Employee.PCL
{
	public class Validator
	{
		public static Tuple<LoginStatus, string> ValidateLogin(string username, string password)
		{
			if (string.IsNullOrEmpty(username))
				return new Tuple<LoginStatus, string>(LoginStatus.Fail, "Please enter username");
			else if (string.IsNullOrEmpty(password))
				return new Tuple<LoginStatus, string>(LoginStatus.Fail, "Please enter password");

			return new Tuple<LoginStatus, string>(LoginStatus.Success, "Login Successful");
		}
	}

	public enum LoginStatus
	{
		Fail,
		Success
	}
}

