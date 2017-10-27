using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Identity.Client;
using EmpTrack.Constants;

namespace EmpTrack.Droid
{
    [Activity(Label = "EmpTrack.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            //         App.PCA1.RedirectUri = "msala7d8cef0-4145-49b2-a91d-95c54051fa3f://auth";
            //App.PCA2.RedirectUri = "msala7d8cef0-4145-49b2-a91d-95c54051fa3f://auth";


            App.PCA1.RedirectUri = APIsConstant.RedirectURLDomain;
			App.PCA2.RedirectUri = APIsConstant.RedirectURLDomain;

            App.UiParent = new UIParent(Xamarin.Forms.Forms.Context as Activity);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }
    }
}
