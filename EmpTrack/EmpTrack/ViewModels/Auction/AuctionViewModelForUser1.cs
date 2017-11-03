using Plugin.Connectivity;
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
using EmpTrack.Constants;

namespace EmpTrack.ViewModels.Auction
{
    class AuctionViewModelForUser1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        INavigation _Navigation;
        public string lot_Num;
        public string client_ID;
        public bool isbusy;
        
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
        public ICommand FetchDetailsCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (String.IsNullOrEmpty(Lot_Num) && String.IsNullOrEmpty(Client_ID)) //if lot# and client id both fields are empty
                    {
				        App.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForAuction, APIsConstant.AlertForAuctionMessage, APIsConstant.OK);
                    }
                    else if (!String.IsNullOrEmpty(Lot_Num) && !String.IsNullOrEmpty(Client_ID)) //if lot# and client id both fields are filled
                    {
                        App.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForAuction, APIsConstant.AlertForAuctionMessage, APIsConstant.OK);
                    }
                    else if(!String.IsNullOrEmpty(Lot_Num) && String.IsNullOrEmpty(Client_ID)) //if lot# is enter
                    {
                        if(CrossConnectivity.Current.IsConnected)
                        {
                            IsBusy = true;
                            FetchCarDetailsByLotNum(); //fetch car detail
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert(APIsConstant.NetworkAlertTitle, APIsConstant.NetworkError, APIsConstant.OK);
                        }           
                    }
                    else if(String.IsNullOrEmpty(Lot_Num) && !String.IsNullOrEmpty(Client_ID)) //if client id is enter
                    {
                        if(CrossConnectivity.Current.IsConnected)
                        {
                            IsBusy = true;
                            FetchClientDetail(); //fetch client detail
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert(APIsConstant.NetworkAlertTitle, APIsConstant.NetworkError, APIsConstant.OK);
                        }
                    }
                });
            }
        }
        public ICommand PersonalLocationCommand
        {
            get
            {
                return new Command(() =>
                {
                    _Navigation.PushAsync(new Views.CustomLocation.CustomLocationPage());
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
                    IsBusy = false;
                    await _Navigation.PushAsync(new Views.ClientDetail.ClientDetailPage(clientResponse.client));
                }
                // if api response is null
                else
                {
                    // show error
                    await Application.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForDataNotFound, APIsConstant.ClientDetailNotFound , APIsConstant.OK);
                    IsBusy = false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForNullApiResponse, APIsConstant.AlertForNullApiResponse, APIsConstant.OK);
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
                    IsBusy = false;
                    await _Navigation.PushAsync(new Views.LotDetail.LotDetailPage(lotResponse.vehicle));
                }
                // if api response is null
                else
                {
                    // show error
                    await Application.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForDataNotFound ,APIsConstant.CarDetailNotFound, APIsConstant.OK);
                    IsBusy = false;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForNullApiResponse, APIsConstant.AlertForNullApiResponse, APIsConstant.OK);
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
