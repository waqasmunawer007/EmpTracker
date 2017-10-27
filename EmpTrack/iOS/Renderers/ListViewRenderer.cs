using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using EmpTrack.Customizations;
using EmpTrack.iOS.Renderers;
using EmpTrack;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CollapsibleListView), typeof(EmpTrack.iOS.Renderers.ListViewRenderer))]
namespace EmpTrack.iOS.Renderers
{
    public class ListViewRenderer :ViewRenderer<CollapsibleListView, UITableView >
    {
    
    public ListViewRenderer()
    {
    }

    protected override void OnElementChanged(ElementChangedEventArgs<CollapsibleListView> e)
    {
        base.OnElementChanged(e);

        if (Control == null)
        {
            SetNativeControl(new UITableView()
            {
                BackgroundColor = UIColor.White,
                RowHeight = NativeListCell.HEIGHT,
                AutoresizingMask = UIViewAutoresizing.All,
                SeparatorStyle = UITableViewCellSeparatorStyle.None,
                Bounces = true,
                BouncesZoom = true,
                ScrollEnabled = true,
                SectionFooterHeight = 0,
                SectionHeaderHeight = NativeListCell.HEIGHT,

                //The following two lines are written to disable the default behaviour of section header movement with cells
                TableHeaderView = new UIView(new CGRect(0, 0, 100, NativeListCell.HEIGHT)),
                ContentInset = new UIEdgeInsets(-NativeListCell.HEIGHT, 0, 0, 0)
            });
        }

        if (e.OldElement != null)
        {
            // unsubscribe
        }

        if (e.NewElement != null)
        {
            // subscribe
            var s = new NativeListView(e.NewElement);
            Control.Source = s;
        }
    }

    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);

        if (e.PropertyName == CollapsibleListView.ItemsProperty.PropertyName)
        {
            // update the Items list in the UITableViewSource
            var s = new NativeListView(Element);
            Control.Source = s;
        }
    }

    public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
    {
        return Control.GetSizeRequest(widthConstraint, heightConstraint, 44, 44);
    }
}
}