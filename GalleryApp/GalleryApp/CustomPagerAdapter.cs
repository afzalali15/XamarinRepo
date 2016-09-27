using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Java.Lang;
using Android.Widget;

namespace GalleryApp
{
    class CustomPagerAdapter : PagerAdapter
    {
        Context _context;
        LayoutInflater _layoutInflater;
        int[] _resources;

        public override int Count
        {
            get
            {
                return _resources.Length;
            }
        }

        public CustomPagerAdapter(Context context, int[] resources)
        {
            _context = context;
            _resources = resources;
            _layoutInflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View itemView = _layoutInflater.Inflate(Resource.Layout.pager_item, container, false);

            ImageView imageView = (ImageView)itemView.FindViewById(Resource.Id.imageView);
            imageView.SetImageResource(_resources[position]);

            container.AddView(itemView);

            return itemView;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objectValue)
        {
            container.RemoveView((LinearLayout)objectValue);
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            return view == ((LinearLayout)objectValue);
        }
    }
}