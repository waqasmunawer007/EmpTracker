using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EmpTrack.Droid.Renderers;
using Xamarin.Forms;
using EmpTrack.Customizations;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CollapsibleListView), typeof(EmpTrack.Droid.Renderers.ListViewRenderer))]
namespace EmpTrack.Droid.Renderers
{
    class ListViewRenderer : ViewRenderer<CollapsibleListView, global::Android.Widget.ExpandableListView>, ExpandableListView.IOnChildClickListener
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CollapsibleListView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(new global::Android.Widget.ExpandableListView(Forms.Context));
            }
            if (e.OldElement != null)
            {
                // unsubscribe
            }
            if (e.NewElement != null)
            {
                // subscribe
                Control.SetAdapter(new DataAdopterListViewRenderer(Forms.Context as Android.App.Activity, e.NewElement.Items));
                Control.SetGroupIndicator(null);
                Control.SetOnChildClickListener(this);
            }
        }
        
        public bool OnChildClick(ExpandableListView parent, Android.Views.View clickedView, int groupPosition, int childPosition, long id)
        {
            var item = DataAdopterListViewRenderer.DataList[groupPosition].vehicle[childPosition];
            if (item != null)
            {
                if (item.OnClickListener != null)
                {
                    item.OnClickListener.Invoke(item);
                }
                else
                {
                    item.IsSelected = !item.IsSelected;
                }
            }
            return false;
        }
    }
}