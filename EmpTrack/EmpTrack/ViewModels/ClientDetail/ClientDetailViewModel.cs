using Services.Models;
using Services.NetworkServices.ClientDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmpTrack.ViewModels.ClientDetail
{
    class ClientDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        INavigation _Navigation;
        public Client clientdetail;
        

        public ClientDetailViewModel(INavigation _navigation, Client _clientdetail)
        {
            _Navigation = _navigation;
            clientdetail = _clientdetail;
        }

        public Client ClientDetail
        {
            get
            {
                return clientdetail;
            }
            set
            {
                clientdetail = value;
                OnPropertyChanged("Clientt");
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
            PropertyChanged(this, new PropertyChangedEventArgs(data));
        }


    }
}
