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
using EmpTrack.Constants;

namespace EmpTrack.ViewModels.Auction
{
    class AuctionViewModelForUser2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        INavigation _Navigation;
        public string lot_Num;
        public string buyer_ID;
        public bool isbusy;
        private ObservableCollection<LotGroupEntity> lotgrouplist;

        public AuctionViewModelForUser2(INavigation _navigation)
        {
            _Navigation = _navigation;
            lotgrouplist = new ObservableCollection<LotGroupEntity>();
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
                OnPropertyChanged("Lot_Num");
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
                OnPropertyChanged("Buyer_ID");
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
                OnPropertyChanged("IsBusy");
            }
        }
        public ObservableCollection<LotGroupEntity> LotGroupList
        {
            get
            {
                return lotgrouplist;
            }
            set
            {
                lotgrouplist = value;
                OnPropertyChanged("LotGroupList");
            }
        }
        public ICommand FetchDetailsCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (String.IsNullOrEmpty(Lot_Num) && String.IsNullOrEmpty(Buyer_ID)) //if lot# and buyer id both fields are empty
                    {
                        App.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForAuction, APIsConstant.AlertForAuction2Message, APIsConstant.OK);
                    }
                    else if (!String.IsNullOrEmpty(Lot_Num) && !String.IsNullOrEmpty(Buyer_ID)) //if lot# and buyer id both fields are filled
                    {
                        App.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForAuction, APIsConstant.AlertForAuction2Message, APIsConstant.OK);
                    }
                    else if (!String.IsNullOrEmpty(Lot_Num) && String.IsNullOrEmpty(Buyer_ID)) //if lot # is enter
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
                    else if (String.IsNullOrEmpty(Lot_Num) && !String.IsNullOrEmpty(Buyer_ID)) //if buyer id is enter
                    {
                        if(CrossConnectivity.Current.IsConnected)
                        {
                            IsBusy = true;
                            FetchLotList();
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert(APIsConstant.NetworkAlertTitle, APIsConstant.NetworkError, APIsConstant.OK);
                        }
                    }
                    
                });
            }
        }
        #region Fetch lotlist against buyer id
        private async void FetchLotList()
        {
            var cardetailservicesssss = new Services.NetworkServices.CarDetails.CarDetailsService();
            LotList lotResponse = await cardetailservicesssss.FetchLotListByBuyerID(Buyer_ID);
            // if api response is not null
            if (lotResponse != null)
            {
                if (lotResponse.Status)
                {
                    var locations = lotResponse.vehicle.GroupBy(x => x.Location).Select(a => new { location = a.Key, count = a.Count() });

                    foreach (var location in locations)
                    {
                        LotGroupEntity groupEntity = new LotGroupEntity();
                        groupEntity.Location = location.location;
                        ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();

                        foreach (Vehicle vehicle in lotResponse.vehicle)
                        {
                            if (vehicle.Location.Equals(location.location))
                            {
                                vehicles.Add(vehicle);
                            }
                        }
                        groupEntity.vehicle = vehicles;
                        LotGroupList.Add(groupEntity);
                    }
                    await _Navigation.PushAsync(new Views.LocationDetail.LocationDetailPage(LotGroupList));
                    IsBusy = false;
                }
                // if api response is null
                else
                {
                    // show error
                    await Application.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForDataNotFound, APIsConstant.LotListNotFound, APIsConstant.OK);
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
                    await Application.Current.MainPage.DisplayAlert(APIsConstant.AlertTitleForDataNotFound, APIsConstant.CarDetailNotFound, APIsConstant.OK);
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

        private void OnPropertyChanged(string data)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(data));
        }
    }
}
