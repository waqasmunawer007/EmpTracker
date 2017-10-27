using EmpTrack.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmpTrack.Customizations
{
    public class CollapsibleListView : View
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create("Items", typeof(List<LotGroupEntity>), typeof(CollapsibleListView), new List<LotGroupEntity>());

        public List<LotGroupEntity> Items
        {
            get { return (List<LotGroupEntity>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        public void NotifyItemSelected(object item)
        {

            if (ItemSelected != null)
                ItemSelected(this, new SelectedItemChangedEventArgs(item));
        }
    }
}
