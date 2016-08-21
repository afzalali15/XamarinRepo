using System;
namespace Employee.PCL
{
	public enum Designation
	{ 
		CEO = 0,
		Manager = 1,
		TL = 2,
		Developer = 3,
		Other = 4
	}

	public class Employee
	{
		public string FirstName
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public string FullName
		{
			get { return $"{FirstName} {LastName}"; }
		}

		public Designation Designation
		{
			get;
			set;
		}
	}
}

