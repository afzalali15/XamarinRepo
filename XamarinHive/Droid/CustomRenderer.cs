using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinHive;
using XamarinHive.Droid;

[assembly : ExportRenderer(typeof(XCheckBox),typeof(XCheckBoxRenderer))]
[assembly : ExportRenderer(typeof(XButton),typeof(XButtonRenderer))]
namespace XamarinHive.Droid
{
	#region XCheckBoxRenderer
	public class XCheckBoxRenderer : ViewRenderer<XCheckBox, CheckBox>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<XCheckBox> e)
		{
			base.OnElementChanged(e);
			var checkBox = new CheckBox(this.Context);

			SetNativeControl(checkBox);
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == "Renderer")
			{
				var xCheckBox = (XCheckBox)Element;
				if (xCheckBox.Text == null)
					throw new Exception("Please assign Text to XCheckBox control");

				this.Control.Text = xCheckBox.Text;
			}
		}
	}
	#endregion


	#region XButtonRenderer
public class XButtonRenderer : ButtonRenderer
{ 
	protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
	{
		base.OnElementChanged(e);
		this.Control.Elevation = 0;
	}

	protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		base.OnElementPropertyChanged(sender, e);

		if (e.PropertyName == "Renderer")
		{
			var xButton = (XButton)Element;
			if (xButton.BackgroundSource != null)
			{
				var backbroundSource = xButton.BackgroundSource;
				var selectorDrawable = Resources.GetDrawable(backbroundSource);
				this.Control.SetCompoundDrawablesWithIntrinsicBounds(null, selectorDrawable, null, null);
			}
		}
	}
}
	#endregion

}

