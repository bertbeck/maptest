using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace maptest.Droid
{
    [Activity (Label = "maptest.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

			//  Initialize dependencies
            global::Xamarin.Forms.Forms.Init (this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

			//  Load and run app
            LoadApplication (new App ());
        }
    }
}

