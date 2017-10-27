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

namespace EmpTrack.ViewModels.Auction
{
    class AuctionViewModelForUser1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        INavigation _Navigation;
        public string lot_Num;
        public string client_ID;
        public Vehicle vehiclee;
        public bool isbusy;
        public Client clientdetails;
        
        public AuctionViewModelForUser1(INavigation _navigation)
        {
            _Navigation = _navigation;
        }

        public string Lot_Num
        {
            get
            {
                return lot_Num;
            }
            set
            {
                lot_Num = value;
                onPropertyChanged("Lot_Num");

            }
        }

        public string Client_ID
        {
            get
            {
                return client_ID;
            }
            set
            {
                client_ID = value;
                onPropertyChanged("Client_ID");

            }
        }

        public bool IsBusy
        {
            get
            {
                return isbusy;
            }
            set
            {
                isbusy = value;
                onPropertyChanged("IsBusy");
            }
        }

        public Vehicle Vehiclee
        {
            get
            {
                return vehiclee;
            }
            set
            {
                vehiclee = value;
                onPropertyChanged("Vehiclee");
            }
        }

        public Client ClientDetails
        {
            get
            {
                return clientdetails;
            }
            set
            {
                clientdetails = value;
                onPropertyChanged("ClientDetails");
            }
        }


        
        public ICommand FetchDetailsCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                    FetchCarDetailsByLotNum();
                });
            }
        }

        
        public ICommand PersonalLocationCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                    FetchClientDetail();
                });
            }
        }



        #region Fetch client detail against client id
        private async void FetchClientDetail()
        {
            var clientdetailservice = new ClientDetailsService();
            ClientDetails clientResponse = await clientdetailservice.FetchClientDetails(Client_ID);
            // if api response is not null
            if (clientResponse != null)
            {
                if (clientResponse.Status)
                {
                    ClientDetails = clientResponse.client;
                    IsBusy = false;
                    _Navigation.PushAsync(new Views.ClientDetail.ClientDetailPage(ClientDetails));
                }
                // if api response is null
                else
                {
                    // show error
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong, check internet settings", "OK");
                    Debug.WriteLine("Error Message : " + clientResponse.ErrorMessage);
                    IsBusy = false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Cancel");
                IsBusy = false;
            }
        }
        #endregion

        #region Fetch car detail against lot ID
        private async void FetchCarDetailsByLotNum()
        {
            var carDetailByLotNum = new Services.NetworkServices.CarDetails.CarDetailsService();
            LotDetails lotResponse = await carDetailByLotNum.FetchCarDetailsByLotNumber(Lot_Num);
            // if api response is not null
            if (lotResponse != null)
            {
                if (lotResponse.Status)
                {
                    //assign to notifuy property
                    Vehiclee = lotResponse.vehicle;
                    IsBusy = false;
                    _Navigation.PushAsync(new Views.LotDetail.LotDetailPage(Vehiclee));
                }
                // if api response is null
                else
                {
                    // show error
                    await Application.Current.MainPage.DisplayAlert("Error", "Somethin went wrong, check internet settings", "OK");
                    Debug.WriteLine("Error Message " + lotResponse.ErrorMessage);
                    IsBusy = false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Cancel");
                IsBusy = false;
            }
        }
        #endregion

        private void onPropertyChanged(string v)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
