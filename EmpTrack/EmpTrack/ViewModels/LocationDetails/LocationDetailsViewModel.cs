using EmpTrack.Constants;
using EmpTrack.Models;
using Services.Models;
using Services.NetworkServices.CarDetails;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmpTrack.ViewModels.LocationDetails
{
    public class LocationDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<LotGroupEntity> lotgrouplist;
        private INavigation _Navigation;
        
        public LocationDetailsViewModel(INavigation _navigation,ObservableCollection<LotGroupEntity> lotgroupList)
        {
            _Navigation = _navigation;
            lotgrouplist = new ObservableCollection<LotGroupEntity>();
            lotgrouplist = lotgroupList;
        }
        public ObservableCollection<LotGroupEntity> LotGroupList
        {
            get
            {
                return lotgrouplist;
            }
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
        
        private void OnPropertyChanged(string data)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(data));
        }
    }
}
