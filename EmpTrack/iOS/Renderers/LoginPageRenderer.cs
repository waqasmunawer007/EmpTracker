using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using EmpTrack.Views.Login;
using EmpTrack.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace EmpTrack.iOS.Renderers
{
    class LoginPageRenderer : PageRenderer
    {
        LoginPage page;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as LoginPage;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}