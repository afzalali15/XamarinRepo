// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOSMapTest
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnShowDialog { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView map { get; set; }

        [Action ("BtnShowDialog_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnShowDialog_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnShowDialog != null) {
                btnShowDialog.Dispose ();
                btnShowDialog = null;
            }

            if (map != null) {
                map.Dispose ();
                map = null;
            }
        }
    }
}