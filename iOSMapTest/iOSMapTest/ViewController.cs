using System;
using CoreLocation;
using Foundation;
using MapKit;
using UIKit;

namespace iOSMapTest
{
    public partial class ViewController : UIViewController
    {

        protected ViewController (IntPtr handle) : base (handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }



        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            map.Delegate = new MapDelegate ();

            map.AddAnnotation (new CustomMKPointAnnotation () {
                Name = "Pikachu",
                StartDate = new DateTime (2016, 07, 20),
                EndDate = new DateTime (2016, 07, 30),
                AnnotationType = PinType.Pokemon,
                Title = "Info",
                Coordinate = new CLLocationCoordinate2D (18.9398, 72.8355)
            });

            map.AddAnnotation (new CustomMKPointAnnotation () {
                Name = "Ghansoli",
                StartDate = new DateTime (2016, 07, 25),
                EndDate = new DateTime (2016, 07, 28),
                AnnotationType = PinType.PokeStop,
                Title = "Info",
                Coordinate = new CLLocationCoordinate2D (19.1254, 72.9992)
            });

            map.AddAnnotation (new CustomMKPointAnnotation () {
                Name = "Doudo",
                StartDate = new DateTime (2016, 07, 25),
                EndDate = new DateTime (2016, 07, 31),
                AnnotationType = PinType.Pokemon,
                Title = "Info",
                Coordinate = new CLLocationCoordinate2D (19.0791, 72.9080)
            });
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnShowDialog_TouchUpInside (UIButton sender)
        {
            //TODO : Implement custom dialog
        }
    }
}

