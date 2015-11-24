using System;
using Xamarin.Forms;
using CoreLocation;
using UIKit;
using maptest;
using maptest.iOS;

[assembly: Dependency (typeof (Util))]


//
//  Dependency: IUTIL
//  Provide location management services
//

namespace maptest.iOS
{
    public class Util : maptest.IUtil
    {
        static CLLocationManager manager;

        public Util ()
        {
        }

        public void EnableLocationServices()
        {
            manager = new CLLocationManager();
            manager.AuthorizationChanged += (sender, args) => {
                Console.WriteLine ("Authorization changed to: {0}", args.Status);
            };
            if (UIDevice.CurrentDevice.CheckSystemVersion(8,0))
                manager.RequestWhenInUseAuthorization();
        }
    }

}

