using Services.Models;
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
    class AuctionViewModelForUser2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        INavigation _Navigation;
        public string lot_Num;
        public string buyer_ID;
        List<LotGroupEntity> vehicle;
        public bool isbusy;
        public Vehicle vehiclee;

        public AuctionViewModelForUser2(INavigation _navigation)
        {
            _Navigation = _navigation;
            vehicle = new List<LotGroupEntity>();
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

        public List<LotGroupEntity> Vehicle
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
                    if(!String.IsNullOrEmpty(Lot_Num))
                    {
                        IsBusy = true;
                        FetchCarDetailsByLotNum();
                    }
                    else if(!String.IsNullOrEmpty(Buyer_ID))
                    {
                        IsBusy = true;
                        FetchLotList();
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


        #region Fetch lot detail list against buyer ID
        private async void FetchLotList()
        {
            Vehicle.Clear();
            var cardetailservicesssss = new Services.NetworkServices.CarDetails.CarDetailsService();
            LotList lotResponse = await cardetailservicesssss.FetchLotListByBuyerID(Buyer_ID);
            // if api response is not null
            if (lotResponse != null )
            {
                if (lotResponse.Status)
                {
                    var locations = lotResponse.vehicle.GroupBy(x => x.Location).Select(a => new { location = a.Key, count = a.Count() });

                    foreach (var location in locations)
                    {
                        LotGroupEntity groupEntity = new LotGroupEntity();
                        groupEntity.Location = location.location;
                        groupEntity.Count = location.count;
                        List<Vehicle> vehicles = new List<Services.Models.Vehicle>();

                        foreach (Vehicle vehicle in lotResponse.vehicle)
                        {
                            if (vehicle.Location.Equals(location.location))
                            {
                                vehicles.Add(vehicle);
                            }
                        }
                        groupEntity.vehicle = vehicles;
                        Vehicle.Add(groupEntity);
                    }

                    IsBusy = false;
                    _Navigation.PushAsync(new Views.LocationDetail.LocationDetailPage(Vehicle));
                }
                // if api response is null
                else
                {

                    // show error
                    await Application.Current.MainPage.DisplayAlert("Error", "Somethin went wrong, check internet settings", "OK");
                    Debug.WriteLine("Error Message : " + lotResponse.ErrorMessage);
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
