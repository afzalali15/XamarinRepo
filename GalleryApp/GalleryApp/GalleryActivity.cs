using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;

namespace GalleryApp
{
    [Activity(Label = "GalleryActivity")]
    public class GalleryActivity : Activity
    {
        int[] _resources = {
            Resource.Drawable.baracktocat,
            Resource.Drawable.bookmyshow,
            Resource.Drawable.chrome,
            Resource.Drawable.facebook,
            Resource.Drawable.flipkart,
            Resource.Drawable.insta,
            Resource.Drawable.whatsapp
        };

        CustomPagerAdapter _customPagerAdapter;
        ViewPager _viewPager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GalleryLayout);

            var index = Intent.Extras.GetInt("index");
            _customPagerAdapter = new CustomPagerAdapter(this, _resources);

            _viewPager = (ViewPager)FindViewById(Resource.Id.pager);
            _viewPager.Adapter = _customPagerAdapter;
            _viewPager.CurrentItem = index;
        }
    }
}