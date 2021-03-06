using Android.App;
using Android.OS;
using Android.Widget;
using Employee.PCL;

namespace Employee.Droid
{
	[Activity(Label = "Employee", MainLauncher = true)]
	public class LoginActivity : BaseActivity
	{
		EditText txtUsername;
		EditText txtPassword;
		Button btnLogin;
		Button btnSignup;

		IDialogProvider dialogProvider;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			dialogProvider = new DialogProvider();
			SetContentView(Resource.Layout.login_activity);

			SetupUserInterface();
			SetupEventHandlers();
		}

		/// <summary>
		/// Find Reference for controls
		/// </summary>
		void SetupUserInterface()
		{
			txtUsername = (EditText)FindViewById(Resource.Id.txtUsername);
			txtPassword = (EditText)FindViewById(Resource.Id.txtPassword);
			btnLogin = (Button)FindViewById(Resource.Id.btnLogin);
			btnSignup = (Button)FindViewById(Resource.Id.btnSignup);
		}

		/// <summary>
		/// Assign events
		/// </summary>
		void SetupEventHandlers()
		{
			btnLogin.Click += async (sender, e) =>
			{
				var username = txtUsername.Text;
				var password = txtPassword.Text;

				//validation
				var validationResult = Validator.ValidateLogin(username, password);
				if (validationResult.Item1 == LoginStatus.Fail)
				{
					dialogProvider.ShowDialog("Alert", validationResult.Item2);
					return;
				}

				//authentication
				dialogProvider.ShowLoading("Authenticating", "Please wait...", false);
				var result = await WebService.AuthenticateAsync(username.Trim(), password.Trim());
				dialogProvider.HideLoading();

				if (result)
				{
					StartActivity(typeof(DashboardActivity));
					Finish();
				}
				else
					dialogProvider.ShowDialog("Failed", "Invalid credentials, Retry!");
			};

			btnSignup.Click += (sender, e) => {
				StartActivity(typeof(SignupActivity));
			};
		}
	}
}

