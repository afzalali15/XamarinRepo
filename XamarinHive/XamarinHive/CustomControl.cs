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

    public class XEntry : Entry
    {
        public string LeftIconSource {
            get;
            set;
        }

        public string RightIconSource {
            get;
            set;
        }

        public string BackgroundSource {
            get;
            set;
        }
    }

    public class XCheckBox : View
    {
        public Action Checked = delegate {
        };

        bool isChecked;
        public bool IsChecked {
            get; set;
        }

        public string Text {
            get;
            set;
        }
    }
}

