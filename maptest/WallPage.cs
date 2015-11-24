using System;
using Xamarin.Forms;

//
//  Create wall for users to post to. Wall is common to all users
//

namespace maptest
{
    public class WallPage : ContentPage
    {
        public WallPage ()
        {
			//  Use our own navigation
            NavigationPage.SetHasNavigationBar(this, false);

			//  Create our custom toolbar
            View toolbar = new Toolbar(this);

			//  Current this is just a stub - show toolbar and heading
            Content = new StackLayout { 
                Children = {
                    toolbar,
                    new Label { Text = "Wall Page" }
                }
            };
        }
    }
}

