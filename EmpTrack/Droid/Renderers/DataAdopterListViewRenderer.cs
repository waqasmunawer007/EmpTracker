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
using EmpTrack.Models;
using Services.Models;

namespace EmpTrack.Droid.Renderers
{
    class DataAdopterListViewRenderer : BaseExpandableListAdapter
    {
        readonly Activity Context;

        public static event EventHandler ProductRestoredCompleted;
        public DataAdopterListViewRenderer(Activity newContext, List<LotGroupEntity> newList) : base ()
		{
            Context = newContext;
            DataList = newList;
        }

        public static List<LotGroupEntity> DataList { get; set; }

        public override Android.Views.View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            View header = convertView;
            if (header == null)
            {
                header = Context.LayoutInflater.Inflate(Resource.Layout.ListViewRenderer, null);
            }
            string parentTitle = DataList[groupPosition].Location;
            int count = DataList[groupPosition].Count;
            header.FindViewById<TextView>(Resource.Id.txtView).Text = parentTitle + " (" + count + ")";
            return header;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = Context.LayoutInflater.Inflate(Resource.Layout.ChildCell, null);
            }
            List<Vehicle> newValue = new List<Vehicle>();
           GetChildViewHelper(groupPosition, out newValue);
            row.FindViewById<TextView>(Resource.Id.txtTitle).Text = newValue[childPosition].LotId;
            return row;
        }

        private void GetChildViewHelper(int groupPosition, out List<Vehicle> newValue)
        {
            var results = DataList[groupPosition].vehicle;
            newValue = results;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            var results = DataList[groupPosition].vehicle == null ? 0 : DataList[groupPosition].vehicle.Count;
            return results;
        }

        public override int GroupCount
        {
            get
            {
                return DataList.Count;
            }
        }
        
        #region implemented abstract members of BaseExpandableListAdapter

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {

            throw new NotImplementedException();
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override bool HasStableIds
        {
            get
            {
                return true;
            }
        }

        #endregion
    }
}