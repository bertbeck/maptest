using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services.Geolocation;
using XLabs.Forms;
using CoreLocation;

//
// IOS Main entry point. We use FinishedLaunching to start the Forms App.
//

namespace maptest.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : XFormsApplicationDelegate
    {
        //CLLocationManager manager = new CLLocationManager();

		//  Called when IOS has finished launching our app

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
			//  Set inversion of control components and initialize dependencies

            this.SetIoc();
            global::Xamarin.Forms.Forms.Init ();
            Xamarin.FormsMaps.Init();
            //global::Xamarin.Forms.SetTitleBarVisibility(AndroidTitleBarVisibility.Never);

            // Code for starting up the Xamarin Test Cloud Agent
            #if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
            #endif

			//  Load and run Forms App
            LoadApplication (new App ());

            return base.FinishedLaunching (app, options);
        }


	//  Inversion of control setup

    private void SetIoc()
    {
        var resolverContainer = new SimpleContainer();

        var app = new XFormsAppiOS();
        app.Init(this);
        resolverContainer.Register<IXFormsApp>(app);

        var documents = app.AppDataDirectory;

		// UNEEDED CONTROLS FOR TEST
        //resolverContainer.Register<IGeolocator, Geolocator>();
        //resolverContainer.Register<IEmailService, EmailService>();
        //resolverContainer.Register<IMediaPicker, MediaPicker>();
        //resolverContainer.Register<IDevice>( t => AppleDevice.CurrentDevice);
        Resolver.SetResolver(resolverContainer.GetResolver());

        DependencyService.Register<Geolocator> ();


        //resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice);
        //Resolver.SetResolver(resolverContainer.GetResolver());

		//  Startup location services

        Util util = new Util ();
        util.EnableLocationServices ();

    }
    }

}

