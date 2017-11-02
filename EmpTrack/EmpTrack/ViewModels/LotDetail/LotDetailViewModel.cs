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
    class LotDetailViewModel : INotifyPropertyChanged
    {
        public INavigation _Navigation;
        private Vehicle vehicle;


        public LotDetailViewModel(INavigation _navigation,Vehicle _vehicle)
        {
            _Navigation = _navigation;
            vehicle = _vehicle;
        }

        public Vehicle Vehiclee
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
                OnPropertyChanged("LotDetail");
            }
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged(this,new PropertyChangedEventArgs(v));
        }

        public ICommand GetQuoteCommand
        {
            get
            {
                return new Command(() =>
                {

                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
