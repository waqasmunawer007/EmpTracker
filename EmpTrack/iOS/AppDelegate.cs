using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.Identity.Client;
using EmpTrack.Models;

namespace EmpTrack.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        public static Models.Enum.DeviceType DeviceType = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? Models.Enum.DeviceType.IPHONE : Models.Enum.DeviceType.IPAD;
        public static double DeviceWidth = UIScreen.MainScreen.Bounds.Width * 2;
        public static double DeviceHeight = UIScreen.MainScreen.Bounds.Height * 2;


        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            App.PCA2.RedirectUri = "msala7d8cef0-4145-49b2-a91d-95c54051fa3f://auth";

            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
            return true;
        }
    }
}
