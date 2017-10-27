using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using EmpTrack.Models;
using EmpTrack.Customizations;
using CoreGraphics;
using Services.Models;

namespace EmpTrack.iOS.Renderers
{
    class NativeListView : UITableViewSource
    {
        public static List<LotGroupEntity> Settings { get; set; }

        protected string cellIdentifier = typeof(NativeListCell).Name;

        public NativeListView()
        {
            Settings = new List<LotGroupEntity>();
        }

        //		public SettingsListSource (List<EntityClass> data)
        //		{
        //			Settings = data;
        //		}

        public NativeListView(CollapsibleListView data)
        {
            Settings = data.Items.ToList();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return (nint)Settings.Count();
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return Settings[(int)section].Location;
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return NativeListCell.HEIGHT;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (Settings[(int)section].IsSelected)
            {
                return (nint)(Settings[(int)section].vehicle != null ? Settings[(int)section].vehicle.Count : 0);
            }
            else
            {
                return 0;
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (OnRowSelected != null)
            {
                OnRowSelected(this, new RowSelectedEventArgs(tableView, indexPath));
            }

            //Code to change the status of the right icon in the row items		
            var item = Settings[indexPath.Section].vehicle[indexPath.Row];
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
                tableView.ReloadSections(NSIndexSet.FromIndex(indexPath.Section), UITableViewRowAnimation.Fade);
            }
            tableView.DeselectRow(indexPath, true);
        }


        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var btn = new UIButton(new CGRect(0, 0, tableView.Frame.Width, NativeListCell.HEIGHT));
            btn.TitleEdgeInsets = new UIEdgeInsets(btn.TitleEdgeInsets.Top, NativeListCell.ParentItemLeftPadding, btn.TitleEdgeInsets.Bottom, btn.TitleEdgeInsets.Right);
            btn.AutoresizingMask = UIViewAutoresizing.All;
            //set section header right side image
            if (!string.IsNullOrEmpty(Settings[(int)section].SelectedStateIcon) && !string.IsNullOrEmpty(Settings[(int)section].DeselectedStateIcon))
            {
                var btnImg = btn.ViewWithTag((int)section);
                if (btnImg != null)
                {
                    btnImg.RemoveFromSuperview();
                }
                var img = !Settings[(int)section].IsSelected ? new UIImageView(UIImage.FromBundle(Settings[(int)section].DeselectedStateIcon)) : new UIImageView(UIImage.FromBundle(Settings[(int)section].SelectedStateIcon));
                img.Tag = (int)section;
                img.Frame = new CGRect(
                    btn.Frame.Width - NativeListCell.HEIGHT - 20,
                    0,
                    NativeListCell.HEIGHT,
                    NativeListCell.HEIGHT
                );
                img.ContentMode = UIViewContentMode.Center;
                img.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin;
                btn.AddSubview(img);
            }

            //ADD SEPERATOR LINE AT BOTTOM
            var seperatorLine = new UIView(new CGRect(0, NativeListCell.HEIGHT - 1, tableView.Frame.Width, 1));
            seperatorLine.BackgroundColor = UIColor.LightGray;
            seperatorLine.Alpha = 0.3f;
            seperatorLine.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            btn.AddSubview(seperatorLine);

            btn.SetTitle(Settings[(int)section].Location, UIControlState.Normal);
            btn.Font = UIFont.BoldSystemFontOfSize(NativeListCell.FontSize);
            btn.BackgroundColor = UIColor.Clear;
            btn.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            btn.SetTitleColor(UIColor.DarkGray, UIControlState.Normal);
            btn.TouchUpInside += (sender, e) => {
                //put in your code to toggle your boolean value here
                if (Settings[(int)section].OnClickListener != null)
                {

                    Settings[(int)section].OnClickListener.Invoke(Settings[(int)section]);
                }

                Settings[(int)section].IsSelected = !Settings[(int)section].IsSelected;

                //reload this section
                tableView.ReloadSections(NSIndexSet.FromIndex(section), UITableViewRowAnimation.Automatic);
            };
            return btn;
        }


        public class RowSelectedEventArgs : EventArgs
        {
            public UITableView tableView { get; set; }

            public NSIndexPath indexPath { get; set; }

            public RowSelectedEventArgs(UITableView tableView, NSIndexPath indexPath) : base()
            {
                this.tableView = tableView;
                this.indexPath = indexPath;
            }
        }

        public event EventHandler<RowSelectedEventArgs> OnRowSelected;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var item = Settings[indexPath.Section].vehicle[indexPath.Row];
            var cell = (NativeListCell)tableView.DequeueReusableCell(cellIdentifier);
            if (cell == null)
                cell = new NativeListCell(UITableViewCellStyle.Default, cellIdentifier, tableView.Frame);

            cell.Title = item.Location;

            if (!string.IsNullOrEmpty(item.SelectedStateIcon) && !string.IsNullOrEmpty(item.DeselectedStateIcon))
            {
                cell.img_RightIcon.Image = !item.IsSelected ? UIImage.FromBundle(item.DeselectedStateIcon) : UIImage.FromBundle(item.SelectedStateIcon);
                cell.img_RightIcon.Hidden = false;
            }
            else
            {
                cell.img_RightIcon.Hidden = true;
            }
            return cell;
        }
    }
}