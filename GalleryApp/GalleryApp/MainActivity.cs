using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace GalleryApp
{
    [Activity(Label = "GalleryApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnFirst, btnMiddle, btnLast;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            btnFirst = (Button)FindViewById(Resource.Id.btnFirst);
            btnMiddle = (Button)FindViewById(Resource.Id.btnMiddle);
            btnLast = (Button)FindViewById(Resource.Id.btnLast);

            btnFirst.Click += Btn_Click;
            btnMiddle.Click += Btn_Click;
            btnLast.Click += Btn_Click;
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            var btn = (Button)sender;
            int index;
            switch (btn.Text)
            {
                case "First":
                    index = 0;
                    break;
                case "Middle":
                    index = 3;
                    break;
                case "Last":
                    index = 6;
                    break;
                default:
                    index = 0;
                    break;
            }

            var intent = new Intent(this, typeof(GalleryActivity));
            intent.PutExtra("index", index);
            StartActivity(intent);
        }
    }
}

