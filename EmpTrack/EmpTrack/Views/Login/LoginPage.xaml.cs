using EmpTrack.ViewModels.User;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            BindingContext = loginViewModel;
        }
        

        //protected override async void OnAppearing()
        //{
        //    // let's see if we have a user in our belly already
        //    try
        //    {
        //        AuthenticationResult ar =
        //            await App.PCA.AcquireTokenSilentAsync(App.Scopes, App.PCA.Users.FirstOrDefault());
        //    }
        //    catch
        //    {
        //        //doesn't matter, we go in interactive more
        //    }
        //}


        //async void OnSignInSignOut(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (btnSignInSignOut.Text == "Sign in")
        //        {
        //            AuthenticationResult ar = await App.PCA.AcquireTokenAsync(App.Scopes, App.UiParent);
        //            btnSignInSignOut.Text = "Sign out";
        //        }
        //        else
        //        {
        //            foreach (var user in App.PCA.Users)
        //            {
        //                App.PCA.Remove(user);
        //            }
        //            btnSignInSignOut.Text = "Sign in";
        //        }
        //    }
        //    catch (Exception ee)
        //    {

        //    }
        //}
    }
}