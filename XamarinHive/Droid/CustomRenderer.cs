using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinHive;
using XamarinHive.Droid;

[assembly: ExportRenderer (typeof (XCheckBox), typeof (XCheckBoxRenderer))]
[assembly: ExportRenderer (typeof (XButton), typeof (XButtonRenderer))]
[assembly: ExportRenderer (typeof (XEntry), typeof (XEntryRenderer))]
namespace XamarinHive.Droid
{
    #region XCheckBoxRenderer
    public class XCheckBoxRenderer : ViewRenderer<XCheckBox, CheckBox>
    {
        protected override void OnElementChanged (ElementChangedEventArgs<XCheckBox> e)
        {
            base.OnElementChanged (e);
            var checkBox = new CheckBox (this.Context);
            if (e.OldElement != null) {
                checkBox.CheckedChange -= checkBox_CheckChanged;
            }
            if (e.NewElement != null) {
                checkBox.CheckedChange += checkBox_CheckChanged;
            }

            SetNativeControl (checkBox);
        }

        void checkBox_CheckChanged (object sender, EventArgs e)
        {
            Element.IsChecked = Control.Checked;
            Element.Checked.Invoke ();
        }

        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);
            if (e.PropertyName == "Renderer") {
                var xCheckBox = (XCheckBox)Element;
                if (xCheckBox.Text != null)
                    Control.Text = xCheckBox.Text;

            }
        }
    }
    #endregion


    #region XButtonRenderer
    public class XButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged (e);
            this.Control.Elevation = 0;
        }

        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName == "Renderer") {
                var xButton = (XButton)Element;
                if (xButton.BackgroundSource != null) {
                    var backbroundSource = xButton.BackgroundSource;
                    var selectorDrawable = Resources.GetDrawable (backbroundSource);
                    this.Control.SetCompoundDrawablesWithIntrinsicBounds (null, selectorDrawable, null, null);
                }
            }
        }
    }
    #endregion

    #region XEntryRenderer
    public class XEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged (e);
        }


        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName == "Renderer") {
                var xEntry = (XEntry)Element;
                if (xEntry.BackgroundSource != null) {
                    var backbroundSource = xEntry.BackgroundSource;
                    var selectorDrawable = this.Context.Resources.GetIdentifier (backbroundSource, "drawable", this.Context.PackageName);
                    Control.SetBackgroundResource (selectorDrawable);
                }

                if (xEntry.LeftIconSource != null) {
                    var leftDrawableSource = xEntry.LeftIconSource;
                    var leftDrawable = Resources.GetDrawable (leftDrawableSource);
                    var drawables = Control.GetCompoundDrawables ();

                    Control.SetCompoundDrawablesWithIntrinsicBounds (leftDrawable, drawables [1], drawables [2], drawables [3]);
                }

                if (xEntry.RightIconSource != null) {
                    var rightDrawableSource = xEntry.RightIconSource;
                    var rightDrawable = Resources.GetDrawable (rightDrawableSource);
                    var drawables = Control.GetCompoundDrawables ();

                    Control.SetCompoundDrawablesWithIntrinsicBounds (drawables [0], drawables [1], rightDrawable, drawables [3]);
                }
            }
        }
    }
    #endregion


}

