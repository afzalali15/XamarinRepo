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
    [Register ("CustomCalloutVeiw")]
    partial class CustomCalloutVeiw
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblValidTill { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (lblValidTill != null) {
                lblValidTill.Dispose ();
                lblValidTill = null;
            }
        }
    }
}