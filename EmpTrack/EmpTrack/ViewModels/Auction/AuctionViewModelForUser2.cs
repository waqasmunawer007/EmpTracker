using Plugin.Connectivity;
using Services.Models;
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

namespace EmpTrack.ViewModels.Auction
{
    class AuctionViewModelForUser2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        INavigation _Navigation;
        public string lot_Num;
        public string buyer_ID;
        ObservableCollection<LotGroupEntity> vehicle;
        public bool isbusy;
        public bool messagevisibility;
        public Vehicle vehiclee;

        public AuctionViewModelForUser2(INavigation _navigation)
        {
            _Navigation = _navigation;
            vehicle = new ObservableCollection<LotGroupEntity>();
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
                onPropertyChanged("ConcatFields");
            }
        }

        public string Buyer_ID
        {
            get
            {
                return buyer_ID;
            }
            set
            {
                buyer_ID = value;
                onPropertyChanged("Buyer_ID");
                onPropertyChanged("ConcatFields");
            }
        }

        public string ConcatFields
        {
            get
            {
                return string.Format("{0},{1}", lot_Num, buyer_ID);  
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

        public bool MessageVisibility
        {
            get
            {
                return messagevisibility;
            }
            set
            {
                messagevisibility = value;
                onPropertyChanged("MessageVisibility");
            }
        }

        public ObservableCollection<LotGroupEntity> Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
                onPropertyChanged("Vehicle");
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


        public ICommand FetchDetailsCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (String.IsNullOrEmpty(Lot_Num) && String.IsNullOrEmpty(Buyer_ID))
                    {
                        App.Current.MainPage.DisplayAlert("", "You should enter atleast one value", "OK");
                    }
                    else if (!String.IsNullOrEmpty(Lot_Num) && !String.IsNullOrEmpty(Buyer_ID))
                    {
                        App.Current.MainPage.DisplayAlert("", "You should enter one value", "OK");
                    }
                    else if (!String.IsNullOrEmpty(Lot_Num) && String.IsNullOrEmpty(Buyer_ID))
                    {
                        if(CrossConnectivity.Current.IsConnected)
                        {
                            IsBusy = true;
                            FetchCarDetailsByLotNum();
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("No Internet", "Please check your internet connection", "OK");
                        }
                    }
                    else if (String.IsNullOrEmpty(Lot_Num) && !String.IsNullOrEmpty(Buyer_ID))
                    {
                        if(CrossConnectivity.Current.IsConnected)
                        {
                            _Navigation.PushAsync(new Views.LocationDetail.LocationDetailPage(Buyer_ID));
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("No Internet", "Please check your internet connection", "OK");
                        }
                    }
                    
                });
            }
        }


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
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong, check internet settings", "OK");
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

        

        private void onPropertyChanged(string data)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(data));
        }
    }
}
