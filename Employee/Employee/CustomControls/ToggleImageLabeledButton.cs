using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Widget;
using Employee.Droid;
using Java.Util.Concurrent.Atomic;

namespace xam.android.control
{
	public class ToggleImageLabeledButton : ImageView
	{

		private int imageOn;
		private int imageOff;
		private AtomicBoolean on = new AtomicBoolean(false);

		public ToggleImageLabeledButton(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			if (attrs != null)
			{
				TypedArray a = context.ObtainStyledAttributes(attrs, Resource.Styleable.image_labeled_button, 0, 0);
				imageOn = a.GetResourceId(Resource.Styleable.image_labeled_button_icon_resource, 0);
				a = context.ObtainStyledAttributes(attrs, Resource.Styleable.toggle_image_labeled_button, 0, 0);
				imageOff = a.GetResourceId(Resource.Styleable.toggle_image_labeled_button_icon_resource_off, 0);
				SetImageResource(imageOff);
			}

		}

		private void handleNewState(bool newState)
		{
			if (newState)
			{
				SetImageResource(imageOn);
			}
			else {
				SetImageResource(imageOff);
			}
		}


		public override void SetOnClickListener(IOnClickListener l)
		{
			bool newState = !on.Get();
			on.Set(newState);
			handleNewState(newState);
			l.OnClick(this);
			
			base.SetOnClickListener(l);
		}


		public void setState(bool b)
		{
			on.Set(b);
			handleNewState(b);
		}
	}
}

