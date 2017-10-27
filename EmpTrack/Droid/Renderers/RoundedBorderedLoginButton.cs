using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using EmpTrack.Droid.Renderers;
using EmpTrack.Customizations;

[assembly: ExportRenderer(typeof(LoginButton), typeof(RoundedBorderedLoginButton))]
namespace EmpTrack.Droid.Renderers
{
    class RoundedBorderedLoginButton : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.LoginRoundedBorderedButton);
            }
        }
    }
}