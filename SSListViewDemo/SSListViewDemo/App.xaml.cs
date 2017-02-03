// **********************************
// FileName : App.xaml.cs
// Author : Afzal Ali
// DateCreated : 31-01-2017
// Description : 
// **********************************
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SSListViewDemo
{
	public partial class App : Application
	{
		public static Color BGColor = Color.FromHex("#dedede");

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ParticipantsPage())
			{
				BarTextColor = Color.White,
				BarBackgroundColor = Color.FromHex("#F44336")
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
