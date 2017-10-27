using EmpTrack.Constants;
using Services.NetworkServices.CarDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Services.Models;
using System.Diagnostics;

namespace EmpTrack.ViewModels.LotDetail
{
    class LotDetailViewModel
    {
        public INavigation _Navigation;

        public LotDetailViewModel(INavigation _navigation)
        {
            _Navigation = _navigation;
        }

        public ICommand GetQuoteCommand
        {
            get
            {
                return new Command(() =>
                {
                    _Navigation.PushAsync(new Views.Pricing.PricingPage());
                });
            }
        }
        

        
    }
}
