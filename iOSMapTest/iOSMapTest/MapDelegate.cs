using System;
using CoreGraphics;
using MapKit;
using UIKit;

namespace iOSMapTest
{
    public class MapDelegate : MKMapViewDelegate
    {
        string pId = "PokePin";

        public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;

            //our annotation which holds all extra informations
            var customAnnotation = (CustomMKPointAnnotation)annotation;


            //create custom callout view
            var customCalloutView = CustomCalloutVeiw.Create ();


            //find annotation by pid
            annotationView = mapView.DequeueReusableAnnotation (pId);


            //if not found then create new
            if (annotationView == null)
                annotationView = new MKAnnotationView (annotation, pId);


            //assign properties of annotation and callout
            annotationView.CanShowCallout = true;
            annotationView.DetailCalloutAccessoryView = customCalloutView;


            //set custom properties here
            customCalloutView.Name.Text = customAnnotation.Name;
            customCalloutView.ValidTill.Text = customAnnotation.EndDate.ToString ("D");

            switch (customAnnotation.AnnotationType) {
            case PinType.Pokemon:
                annotationView.Image = UIImage.FromFile ("pokeball.png");
                break;
            case PinType.PokeStop:
                annotationView.Image = UIImage.FromFile ("pokestop.png");
                break;
            default:
                break;
            }

            return annotationView;
        }

    }
}

