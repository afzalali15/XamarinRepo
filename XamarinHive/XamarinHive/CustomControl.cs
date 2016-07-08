using System;
using Xamarin.Forms;

namespace XamarinHive
{
    public class XButton : Button
    {
        public string BackgroundSource {
            get;
            set;
        }
    }

    public class XCheckBox : View
    {
        public bool IsChecked {
            get;
            set;
        }
        public string Text {
            get;
            set;
        }
    }
}

