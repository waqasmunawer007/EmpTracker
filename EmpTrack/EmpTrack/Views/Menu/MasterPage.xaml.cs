using EmpTrack.Models;
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
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MasterPage()
        {
            InitializeComponent();
            if (Helpers.Settings.DomainType == 1)
            {
                listView.ItemsSource = GetMenuForDomain1();
            }
            else
            {
                listView.ItemsSource = GetMenuForDomain2();
            }

            UserName.Text = Helpers.Settings.UserName;
        }
        private List<MasterPageItem> GetMenuForDomain1()
        {
            var masterPageItem = new List<MasterPageItem>();
            masterPageItem.Add(new MasterPageItem
            {
                Title = "My Profile",
                IconSource = "User.png",
                TargetType = typeof(Views.Profile.MyProfile)
            });
            masterPageItem.Add(new MasterPageItem
            {
                Title = "Policy Menu",
                IconSource = "Policy.png",
                TargetType = typeof(Views.PolicyMenu.PolicyMenuPage)
            });
            masterPageItem.Add(new MasterPageItem
            {
                Title="Auction",
                IconSource="Auction.png",
                TargetType=typeof(Views.Auction.AuctionPageForUser2)
            });
            masterPageItem.Add(new MasterPageItem
            {
                Title = "About Us",
                IconSource = "About.png",
                TargetType = typeof(Views.AboutUs.AboutUsPage)
            });
            masterPageItem.Add(new MasterPageItem
            {
                Title = "Send Feedback",
                IconSource = "Feedback.png",
                TargetType = typeof(Views.SendFeedback.SendFeedbackPage)
            });
            masterPageItem.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "Settings.png",
                TargetType = typeof(Views.Settings.SettingsPage2)
            });
            masterPageItem.Add(new MasterPageItem
            {
                Title = "Logout",
                IconSource = "Logout.png"
            });
            return masterPageItem;
        }

        private List<MasterPageItem> GetMenuForDomain2()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Employee Profile",
                IconSource = "User.png",
                TargetType = typeof(Views.Profile.EmpProfile)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Usage",
                IconSource = "Usage.png",
                TargetType = typeof(Views.Usage.UsagePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Policy Menu",
                IconSource = "Policy.png",
                TargetType = typeof(Views.PolicyMenu.PolicyMenuPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "News",
                IconSource = "News.png",
                TargetType = typeof(Views.News.NewsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Notifications",
                IconSource = "Notifications.png",
                TargetType = typeof(Views.Notifications.NotificationsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "About Us",
                IconSource = "About.png",
                TargetType = typeof(Views.AboutUs.AboutUsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Send Feedback",
                IconSource = "Feedback.png",
                TargetType = typeof(Views.SendFeedback.SendFeedbackPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "Settings.png",
                TargetType = typeof(Views.Settings.SettingsPage2)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Logout",
                IconSource = "Logout.png"
            });
            return masterPageItems;
        }
    }
}