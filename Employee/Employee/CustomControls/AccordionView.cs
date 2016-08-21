using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using Android.Widget;
using Employee.Droid;
using Java.Lang;

namespace xam.android.control
{
	public class AccordionView : LinearLayout
	{
		private bool initialized = false;

		// -- from xml parameter
		private int headerLayoutId;
		private int headerFoldButton;
		private int headerLabel;
		private int sectionContainer;
		private int sectionContainerParent;
		private int sectionBottom;

		private string[] sectionHeaders;

		private View[] children;
		private View[] wrappedChildren;
		private View[] headers;
		private View[] footers;
		private View[] sectionContainers;

		private Dictionary<int, View> sectionByChildId = new Dictionary<int, View>();

		private int[] sectionVisibilities = new int[0];


		public AccordionView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			if (attrs != null)
			{
				TypedArray a = context.ObtainStyledAttributes(attrs, Resource.Styleable.accordion);
				headerLayoutId = a.GetResourceId(Resource.Styleable.accordion_header_layout_id, 0);
				headerFoldButton = a.GetResourceId(Resource.Styleable.accordion_header_layout_fold_button_id, 0);
				headerLabel = a.GetResourceId(Resource.Styleable.accordion_header_layout_label_id, 0);
				sectionContainer = a.GetResourceId(Resource.Styleable.accordion_section_container, 0);
				sectionContainerParent = a.GetResourceId(Resource.Styleable.accordion_section_container_parent, 0);
				sectionBottom = a.GetResourceId(Resource.Styleable.accordion_section_bottom, 0);
				int sectionHeadersResourceId = a.GetResourceId(Resource.Styleable.accordion_section_headers, 0);
				int sectionVisibilityResourceId = a.GetResourceId(Resource.Styleable.accordion_section_visibility, 0);

				if (sectionHeadersResourceId == 0)
				{
					throw new IllegalArgumentException("Please set section_headers as reference to strings array.");
				}
				sectionHeaders = Resources.GetStringArray(sectionHeadersResourceId);

				if (sectionVisibilityResourceId != 0)
				{
					sectionVisibilities = Resources.GetIntArray(sectionVisibilityResourceId);
				}
			}

			if (headerLayoutId == 0 || headerLabel == 0 || sectionContainer == 0 || sectionContainerParent == 0 || sectionBottom == 0)
			{
				throw new IllegalArgumentException(
					"Please set all header_layout_id,  header_layout_label_id, section_container, section_container_parent and section_bottom attributes.");
			}

			Orientation = Android.Widget.Orientation.Vertical;
		}

		private void assertWrappedChildrenPosition(int position)
		{
			if (wrappedChildren == null || position >= wrappedChildren.Length)
			{
				throw new IllegalArgumentException("Cannot toggle section " + position + ".");
			}
		}

		public View getChildById(int id)
		{
			for (int i = 0; i < wrappedChildren.Length; i++)
			{
				View v = wrappedChildren[i].FindViewById(id);
				if (v != null)
				{
					return v;
				}
			}
			return null;
		}

		public View getSectionByChildId(int id)
		{
			return sectionByChildId[id];
		}



		View getView(LayoutInflater inflater, int i, bool hide)
		{
			View container = inflater.Inflate(sectionContainer, null);
			container.LayoutParameters = new ListView.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, 0);
			ViewGroup newParent = (ViewGroup)container.FindViewById(sectionContainerParent);
			newParent.AddView(children[i]);


			//FontUtils.setCustomFont(container, AccordionView.this.getContext().getAssets());
			if (container.Id == -1)
			{
				container.Id = i;
			}

			if (hide)
			{
				container.Visibility = ViewStates.Gone;
			}

			var view = children[i];
			var btn = view.FindViewWithTag(new Java.Lang.String("done"));

			if (btn != null)
			{
				btn.Tag = i;
				if (btn is Button)
				{
					btn.Click += (sender, e) =>
					{
						var currentSection = (int)btn.Tag;
						var nextSection = currentSection + 1;

						toggleSection(currentSection);
						if (nextSection < children.Length)
						{
							toggleSection(nextSection);
						}
					};
				}
			}

			return container;
		}

		private View getViewFooter(LayoutInflater inflater)
		{
			return inflater.Inflate(sectionBottom, null);
		}

		private View getViewHeader(LayoutInflater inflater, int position, bool hide)
		{
			View view = inflater.Inflate(headerLayoutId, null);
			((TextView)view.FindViewById(headerLabel)).Text = sectionHeaders[position];

			//FontUtils.setCustomFont(view, AccordionView.this.getContext().getAssets());

			// -- support for no fold button
			if (headerFoldButton == 0)
			{
				return view;
			}

			View foldButton = view.FindViewById(headerFoldButton);

			if (foldButton is ToggleImageLabeledButton)
			//if (foldButton.GetType().IsAssignableFrom(typeof(ToggleImageLabeledButton)))
			{
				ToggleImageLabeledButton toggleButton = (ToggleImageLabeledButton)foldButton;
				toggleButton.setState(wrappedChildren[position].Visibility == ViewStates.Visible);
			}

			foldButton.Click += (sender, e) =>
			{
				var pos = position == 0 ? position : position - 1;
				//if previous category is bieng viewed then only open other category
				if (sectionVisibilities[pos] == 1)
				{
					toggleSection(position);
				}
			};

			view.Click += (sender, e) =>
			{
				foldButton.CallOnClick();
				if (foldButton is ToggleImageLabeledButton)
				{
					ToggleImageLabeledButton toggleButton = (ToggleImageLabeledButton)foldButton;
					toggleButton.setState(wrappedChildren[position].Visibility == ViewStates.Visible);
				}
			};

			return view;
		}


		protected override void OnFinishInflate()
		{
			if (initialized)
			{
				base.OnFinishInflate();
				return;
			}

			int childCount = ChildCount;
			sectionContainers = new View[childCount];
			children = new View[childCount];
			headers = new View[childCount];
			footers = new View[childCount];
			wrappedChildren = new View[childCount];

			if (sectionHeaders.Length != childCount)
			{
				throw new IllegalArgumentException("Section headers string array Length must be equal to accordion view child count.");
			}

			LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);

			for (int i = 0; i < childCount; i++)
			{
				children[i] = GetChildAt(i);
			}
			RemoveAllViews();

			for (int i = 0; i < childCount; i++)
			{
				bool hide = sectionVisibilities.Length > 0 && sectionVisibilities[i] == 0;

				wrappedChildren[i] = getView(inflater, i, hide);
				headers[i] = getViewHeader(inflater, i, hide);
				footers[i] = getViewFooter(inflater);
				LinearLayout section = new LinearLayout(Context);
				sectionContainers[i] = section;
				section.Orientation = Android.Widget.Orientation.Vertical;
				section.AddView(headers[i]);
				section.AddView(wrappedChildren[i]);
				section.AddView(footers[i]);

				if (!sectionByChildId.ContainsKey(children[i].Id))
					sectionByChildId.Add(children[i].Id, section);

				AddView(section);
			}

			initialized = true;
			base.OnFinishInflate();
		}


		public ViewStates getSectionVisibility(int position)
		{
			assertWrappedChildrenPosition(position);
			return wrappedChildren[position].Visibility;
		}


		public void setSectionVisibility(int position, ViewStates visibility)
		{
			assertWrappedChildrenPosition(position);
			wrappedChildren[position].Visibility = visibility;
			if (headerFoldButton != 0)
			{
				View foldButton = headers[position].FindViewById(headerFoldButton);
				if (foldButton is ToggleImageLabeledButton)
				{
					ToggleImageLabeledButton toggleButton = (ToggleImageLabeledButton)foldButton;
					toggleButton.setState(wrappedChildren[position].Visibility == ViewStates.Visible);
				}
			}
		}

		public void toggleSection(int position)
		{
			assertWrappedChildrenPosition(position);

			if (wrappedChildren[position].Visibility == ViewStates.Visible)
				setSectionVisibility(position, ViewStates.Gone);
			else
				setSectionVisibility(position, ViewStates.Visible);


			sectionVisibilities[position] = 1;
		}


		public void setChildVisibility(int position, ViewStates visibility)
		{
			assertWrappedChildrenPosition(position);
			sectionContainers[position].Visibility = visibility;
		}

	}
}

