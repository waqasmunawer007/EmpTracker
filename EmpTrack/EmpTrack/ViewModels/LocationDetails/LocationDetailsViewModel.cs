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
using Xamarin.Forms;

namespace EmpTrack.ViewModels.LocationDetails
{
    public class LocationDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<LotGroupEntity> lotgrouplist;
        private INavigation _Navigation;
        private string Buyer_ID;
        private bool isbusy;
        private bool visibility;

        public LocationDetailsViewModel(INavigation _navigation, string buyer_id)
        {
            _Navigation = _navigation;
            Buyer_ID = buyer_id;
            lotgrouplist = new ObservableCollection<LotGroupEntity>();
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

        public bool Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }


        #region Fetch lot detail list against buyer ID
        public async Task FetchLotList()
        {
            IsBusy = true;
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

                    IsBusy = false;
                    Visibility = true;
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






        private void OnPropertyChanged(string data)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(data));
        }
    }
}
