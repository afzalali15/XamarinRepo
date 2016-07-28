using Foundation;
using System;
using UIKit;
using ObjCRuntime;

namespace iOSMapTest
{
    public partial class CustomCalloutVeiw : UIView
    {
        public UILabel Name {
            get { return lblName; }
        }

        public UILabel ValidTill {
            get { return lblValidTill; }
        }


        public CustomCalloutVeiw (IntPtr handle) : base (handle)
        {
        }

        public static CustomCalloutVeiw Create ()
        {
            var arr = NSBundle.MainBundle.LoadNib ("CustomCallout", null, null);
            var v = Runtime.GetNSObject<CustomCalloutVeiw> (arr.ValueAt (0));

            return v;
        }

        public override void AwakeFromNib ()
        {

        }
    }
}