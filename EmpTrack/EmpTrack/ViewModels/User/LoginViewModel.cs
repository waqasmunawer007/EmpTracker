using EmpTrack.Constants;
using EmpTrack.Helpers;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace EmpTrack.ViewModels.User
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        { }

        public ICommand CustomerCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage = new NavigationPage(new Views.Auction.AuctionPageForUser1());
                });
            }
        }


        public ICommand DealerCommand
        {
            get
            {
                //return new Command(() =>
                //{
                //    Settings.DomainType = 1;
                //    App.Current.MainPage = new NavigationPage(new Views.Auction.AuctionPageForUser2());
                //});
                return new Command(async () =>
                {
                    try
                    {
                        Settings.DomainType = 1;
                        if (!String.IsNullOrEmpty(Settings.Email))
                        {
                            Application.Current.MainPage = new Views.Menu.MainPage();
                        }
                        else if (String.IsNullOrEmpty(Settings.Email))
                        {
                            AuthenticationResult ar = await App.PCA1.AcquireTokenAsync(App.Scopes, App.UiParent);
                            Settings.UserName = ar.User.Name;
                            Settings.Email = ar.User.DisplayableId;
                            foreach (var user in App.PCA1.Users)
                            {
                                App.PCA1.Remove(user);
                            }
                            Application.Current.MainPage = new Views.Auction.AuctionPageForUser2();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Exception " + ex.Message);
                    }
                });
            }
        }

        public ICommand ServiceProviderCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
						Settings.DomainType = 2;
                        if (!String.IsNullOrEmpty(Settings.Email))
                        {
                            Application.Current.MainPage = new Views.Menu.MainPage();
                        }
                        else if (String.IsNullOrEmpty(Settings.Email))
                        {
                            AuthenticationResult ar = await App.PCA2.AcquireTokenAsync(App.Scopes, App.UiParent);
							Settings.UserName = ar.User.Name;
							Settings.Email = ar.User.DisplayableId;
                            foreach (var user in App.PCA2.Users)
                            {
                                App.PCA2.Remove(user);
                            }
                            Application.Current.MainPage = new Views.Menu.MainPage();
                        }
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine("Exception "+ex.Message);
                    }
                });
            }
        }


        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
