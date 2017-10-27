using EmpTrack.Models;
using EmpTrack.Views.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        MasterPage masterPage;
        public MainPage()
        {
            InitializeComponent();
            masterPage = new MasterPage();
            Master = masterPage;
            if (Helpers.Settings.DomainType == 1)
            {
                Detail = new NavigationPage(new MyProfile());
            }
            else
            {
                Detail = new NavigationPage(new EmpProfile());
            }


            masterPage.ListView.ItemSelected += OnItemSelected;
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if (!item.Title.Equals("Logout"))
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
                else
                {
                    //Perform logout here
                    Helpers.Settings.Email = String.Empty;
                    Helpers.Settings.UserName = String.Empty;
                    App.Current.MainPage = new Views.Login.LoginPage();

                }

            }
        }
    }
}