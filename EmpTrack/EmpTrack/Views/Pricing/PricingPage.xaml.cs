using EmpTrack.ViewModels.Pricing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.Pricing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PricingPage : ContentPage
    {
        PricingViewModel pricingViewModel;
        ObservableCollection<PricingViewModel> alldata;

        public PricingPage()
        {
            InitializeComponent();
            pricingViewModel = new PricingViewModel();
            alldata = pricingViewModel.getdata();
            UpdateList();
        }

        private void UpdateList()
        {
            locations.ItemsSource = alldata;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            pricingViewModel.Check = !pricingViewModel.Check;

            var ab = e as TappedEventArgs;
            if (ab.Parameter.ToString() == "id")
            {
                if (pricingViewModel.Check)
                {
                    locations.ItemsSource = alldata.OrderBy(a => a.id);
                }
                else if (!pricingViewModel.Check)
                {
                    locations.ItemsSource = alldata.OrderByDescending(a => a.id).ToList();
                }
            }
            else if (ab.Parameter.ToString() == "price")
            {
                if (pricingViewModel.Check)
                {
                    locations.ItemsSource = alldata.OrderBy(a => a.price);
                }
                else if (!pricingViewModel.Check)
                {
                    locations.ItemsSource = alldata.OrderByDescending(a => a.price).ToList();
                }
            }
            else if (ab.Parameter.ToString() == "distance")
            {
                if (pricingViewModel.Check)
                {
                    locations.ItemsSource = alldata.OrderBy(a => a.distance);
                }
                else if (!pricingViewModel.Check)
                {
                    locations.ItemsSource = alldata.OrderByDescending(a => a.distance).ToList();
                }
            }
            
        }
    }
}