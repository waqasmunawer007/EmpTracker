using EmpTrack.Constants;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace EmpTrack
{
    public partial class App : Application
    {
        public static PublicClientApplication PCA1 = null;
        public static PublicClientApplication PCA2 = null;
        public static string[] Scopes = { "User.Read" };
        public static string Username = string.Empty;

        public static UIParent UiParent = null;


        public App()
        {
            InitializeComponent();
            PCA1 = new PublicClientApplication(APIsConstant.ClientIDForDomain1);
            PCA2 = new PublicClientApplication(APIsConstant.ClientIDForDomain2);
            MainPage = new NavigationPage(new Views.Login.LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
