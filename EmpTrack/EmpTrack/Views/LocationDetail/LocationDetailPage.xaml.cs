using EmpTrack.Customizations;
using EmpTrack.ViewModels.LocationDetails;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.LocationDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationDetailPage : ContentPage
    {
        CollapsibleListView nativeListView2 = null;
        List<LotGroupEntity> Vehicle;

        public LocationDetailPage(List<LotGroupEntity> vehicle)
        {
            InitializeComponent();
            Vehicle = new List<LotGroupEntity>();
            Vehicle = vehicle;
            UpdateView();
        }
    
        private void UpdateView()
        {
            
            nativeListView2 = new CollapsibleListView();
            // REQUIRED: To share a scrollable view with other views in a StackLayout, it should have a VerticalOptions of FillAndExpand.
            nativeListView2.VerticalOptions = LayoutOptions.FillAndExpand;
            nativeListView2.Items = Vehicle;
            
            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children = {
                    nativeListView2
                }
            };
            
        }
    }
}