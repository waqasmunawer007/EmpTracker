using EmpTrack.Customizations;
using EmpTrack.ViewModels.LocationDetails;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.LocationDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationDetailPage : ContentPage
    {
        LocationDetailsViewModel locationdetailViewModel;
        private ObservableCollection<LotGroupEntity> _allGroups;
        private ObservableCollection<LotGroupEntity> _expandedGroups;
        private List<string> parent = new List<string>();

        public LocationDetailPage(string buyer_id)
        {
            InitializeComponent();
            locationdetailViewModel = new LocationDetailsViewModel(Navigation,buyer_id);
            BindingContext = locationdetailViewModel;
            _allGroups = locationdetailViewModel.LotGroupList;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            getLotList();
        }

        private async void getLotList()
        {
            await locationdetailViewModel.FetchLotList();
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedGroups.IndexOf(
                ((LotGroupEntity)((Button)sender).CommandParameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        public void ParentCheckedChaned(object sender, EventArgs args)
        {
            var selectedIndex = _expandedGroups.IndexOf(((LotGroupEntity)((Messier16.Forms.Controls.Checkbox)sender).BindingContext as LotGroupEntity));

            var selectedItem = ((LotGroupEntity)((Messier16.Forms.Controls.Checkbox)sender).BindingContext as LotGroupEntity);

            if (_allGroups[selectedIndex].Expanded == false)
            {
                if (selectedItem._Checked == false)
                {
                    _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;

                    _expandedGroups = new ObservableCollection<LotGroupEntity>();

                    foreach (LotGroupEntity lotgroup in _allGroups)
                    {
                        LotGroupEntity newGroup = new LotGroupEntity(lotgroup.Location, lotgroup.Expanded);
                        newGroup.ItemsCount = lotgroup.vehicle.Count();


                        if (lotgroup.Expanded)
                        {
                            if (lotgroup.Location == selectedItem.Location)
                            {
                                parent.Remove(lotgroup.Location);
                            }

                            foreach (Vehicle vehicle in lotgroup.vehicle)
                            {
                                if (lotgroup.Location == selectedItem.Location)
                                {
                                    vehicle.check = false;
                                    newGroup.Add(vehicle);
                                }
                                else
                                {
                                    if (vehicle.check == true)
                                    {
                                        vehicle.check = true;
                                        newGroup.Add(vehicle);
                                    }
                                    else
                                    {
                                        vehicle.check = false;
                                        newGroup.Add(vehicle);
                                    }
                                }
                            }
                        }
                        _expandedGroups.Add(newGroup);
                    }
                    foreach (var i in _expandedGroups)
                    {
                        foreach (var j in parent)
                        {
                            if (i.Location == j)
                            {
                                i._Checked = true;
                            }
                        }
                    }

                    GroupedView.ItemsSource = _expandedGroups;

                }
                else if (selectedItem._Checked == true)
                {
                    _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;

                    _expandedGroups = new ObservableCollection<LotGroupEntity>();
                    foreach (LotGroupEntity lotgroup in _allGroups)
                    {
                        LotGroupEntity newGroup = new LotGroupEntity(lotgroup.Location,lotgroup.Expanded);
                        newGroup.ItemsCount = lotgroup.vehicle.Count();


                        if (lotgroup.Expanded)
                        {
                            if (lotgroup.Location == selectedItem.Location)
                            {
                                parent.Add(lotgroup.Location);
                            }

                            foreach (Vehicle vehicle in lotgroup.vehicle)
                            {
                                if (lotgroup.Location == selectedItem.Location)
                                {
                                    vehicle.check = true;
                                    newGroup.Add(vehicle);
                                }
                                else
                                {
                                    if (vehicle.check == true)
                                    {
                                        vehicle.check = true;
                                        newGroup.Add(vehicle);
                                    }
                                    else
                                    {
                                        vehicle.check = false;
                                        newGroup.Add(vehicle);
                                    }
                                }
                            }
                        }


                        _expandedGroups.Add(newGroup);
                    }
                    foreach (var i in _expandedGroups)
                    {
                        foreach (var j in parent)
                        {
                            if (i.Location == j)
                            {
                                i._Checked = true;
                            }
                        }
                    }

                    GroupedView.ItemsSource = _expandedGroups;
                }

            }

            else if (_allGroups[selectedIndex].Expanded == true)
            {
                if (selectedItem._Checked == false)
                {
                    _expandedGroups = new ObservableCollection<LotGroupEntity>();
                    foreach (LotGroupEntity lotgroup in _allGroups)
                    {
                        LotGroupEntity newGroup = new LotGroupEntity(lotgroup.Location,lotgroup.Expanded);
                        newGroup.ItemsCount = lotgroup.vehicle.Count();


                        if (lotgroup.Expanded)
                        {
                            if (lotgroup.Location == selectedItem.Location)
                            {
                                parent.Remove(lotgroup.Location);
                            }

                            foreach (Vehicle vehicle in lotgroup.vehicle)
                            {
                                if (lotgroup.Location == selectedItem.Location)
                                {
                                    vehicle.check = false;
                                    newGroup.Add(vehicle);
                                }
                                else
                                {
                                    if (vehicle.check == true)
                                    {
                                        vehicle.check = true;
                                        newGroup.Add(vehicle);
                                    }
                                    else
                                    {
                                        vehicle.check = false;
                                        newGroup.Add(vehicle);
                                    }
                                }
                            }
                        }
                        _expandedGroups.Add(newGroup);
                    }
                    foreach (var i in _expandedGroups)
                    {
                        foreach (var j in parent)
                        {
                            if (i.Location == j)
                            {
                                i._Checked = true;
                            }
                        }
                    }

                    GroupedView.ItemsSource = _expandedGroups;
                }

                else if (selectedItem._Checked == true)
                {
                    _expandedGroups = new ObservableCollection<LotGroupEntity>();
                    foreach (LotGroupEntity lotgroup in _allGroups)
                    {
                        LotGroupEntity newGroup = new LotGroupEntity(lotgroup.Location,lotgroup.Expanded);
                        newGroup.ItemsCount = lotgroup.vehicle.Count();

                        if (lotgroup.Expanded)
                        {
                            if (lotgroup.Location == selectedItem.Location)
                            {
                                parent.Add(lotgroup.Location);
                            }

                            foreach (Vehicle vehicle in lotgroup.vehicle)
                            {
                                if (lotgroup.Location == selectedItem.Location)
                                {
                                    vehicle.check = true;
                                    newGroup.Add(vehicle);
                                }
                                else
                                {
                                    if (vehicle.check == true)
                                    {
                                        vehicle.check = true;
                                        newGroup.Add(vehicle);
                                    }
                                    else
                                    {
                                        vehicle.check = false;
                                        newGroup.Add(vehicle);
                                    }
                                }
                            }
                        }


                        _expandedGroups.Add(newGroup);
                    }
                    foreach (var i in _expandedGroups)
                    {
                        foreach (var j in parent)
                        {
                            if (i.Location == j)
                            {
                                i._Checked = true;
                            }
                        }
                    }

                    GroupedView.ItemsSource = _expandedGroups;
                }

            }

        }



        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<LotGroupEntity>();
            foreach (LotGroupEntity lotgroup in _allGroups)
            {
                //Create new FoodGroups so we do not alter original list
                LotGroupEntity newGroup = new LotGroupEntity(lotgroup.Location, lotgroup.Expanded);
                //Add the count of food items for Lits Header Titles to use
                newGroup.ItemsCount = lotgroup.vehicle.Count();
                if (lotgroup.Expanded)
                {
                    foreach (Vehicle vehicle in lotgroup.vehicle)
                    {
                        newGroup.Add(vehicle);
                    }
                }

                _expandedGroups.Add(newGroup);
            }
            foreach (var i in _expandedGroups)
            {
                foreach (var j in parent)
                {
                    if (i.Location == j)
                    {
                        i._Checked = true;
                    }
                }
            }
            GroupedView.ItemsSource = _expandedGroups;
        }

    }
}