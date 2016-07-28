using System;
using MapKit;

namespace iOSMapTest
{
    public enum PinType
    {
        Pokemon,
        PokeStop,
    }

    public class CustomMKPointAnnotation : MKPointAnnotation
    {
        public PinType AnnotationType {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public DateTime StartDate {
            get;
            set;
        }

        public DateTime EndDate {
            get;
            set;
        }
    }
}

