
using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Employee.Shared;

namespace Employee.Droid
{
	[Activity(Label = "DashboardActivity")]
	public class DashboardActivity : BaseActivity
	{
		Button btnWelcome;
		MapFragment mapFrag;
		IDialogProvider dialogProvider;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			dialogProvider = new DialogProvider();
			SetContentView(Resource.Layout.dashboard_activity);


			SetupUserInterface();
			SetupEventHandlers();


			var location = new LatLng(19.0912, 72.9209);
			CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
			builder.Target(location);
			builder.Zoom(15);
			var cameraPosition = builder.Build();
			var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);


			var map = mapFrag.Map;
			if (map != null)
			{
				map.MoveCamera(cameraUpdate);
				MarkerOptions markerOpt1 = new MarkerOptions();
				markerOpt1.SetPosition(new LatLng(19.0912, 72.9209));
				markerOpt1.SetTitle("Afzal Ali");
				map.AddMarker(markerOpt1);
			}

			//mapFrag.GetMapAsync(new MapCallBack());
		}


		void SetupUserInterface()
		{
			btnWelcome = (Button)FindViewById(Resource.Id.btnWelcome);
			mapFrag = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
		}

		void SetupEventHandlers()
		{
			btnWelcome.Click += (sender, e) =>
			{
				dialogProvider.ShowDialog("Success", "Welcome!");
			};
		}
	}


	//class MapCallBack : Java.Lang.Object, IOnMapReadyCallback
	//{
	//	CameraUpdate cameraUpdate;
	//	public MapCallBack()
	//	{
	//		LatLng location = new LatLng(19.0912, 72.9209);
	//		CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
	//		builder.Target(location);
	//		builder.Zoom(18);
	//		//builder.Bearing(155);
	//		//builder.Tilt(65);
	//		CameraPosition cameraPosition = builder.Build();
	//		cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
	//	}

	//	public void OnMapReady(GoogleMap googleMap)
	//	{
	//		// The GoogleMap object is ready to go.
	//		googleMap.MoveCamera(cameraUpdate);

	//		MarkerOptions markerOpt1 = new MarkerOptions();
	//		markerOpt1.SetPosition(new LatLng(19.0912, 72.9209));
	//		markerOpt1.SetTitle("Afzal Ali");
	//		googleMap.AddMarker(markerOpt1);
	//	}
	//}
}

