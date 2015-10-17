using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace maptest
{
    public class Toolbar : ContentView
    {
        static Toolbar _toolbar;
        public void Toolbarxxx ()
        {
        }

        static List<ToolbarItem> topMenuList; 
        static StackLayout topMenu; 
        static Dictionary<Image,ToolbarItem> toolbarItems = new Dictionary<Image, ToolbarItem>();

        static int wallNewMessageCount = 15;
        static int newMessageCount = 5;


        public Toolbar(ContentPage page)
        {
            if (_toolbar != null) {
                Content = _toolbar.Content;
                return;
            }

            topMenuList = new List<ToolbarItem> ();
            topMenu = new StackLayout {BackgroundColor = Color.White, Orientation = StackOrientation.Horizontal, HorizontalOptions=LayoutOptions.FillAndExpand, Padding = new Thickness (0,0,10,0)};

            topMenuList.Add(new ToolbarItem {
                Text = "Search",
                Icon = "search_blue.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => {Navigation.PushAsync (new Test.TestPage ());})
            });


            topMenuList.Add(new ToolbarItem {
                Text = "Wall",
                Icon = "newspaper_gray.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => {Navigation.PushAsync (new WallPage ());})
            });

            topMenuList.Add(new ToolbarItem {
                Text = "Messages",
                Icon = "envelope_gray.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => {Navigation.PushAsync (new MessagesPage ());})
            });

            topMenuList.Add(new ToolbarItem {
                Text = "Map",
                Icon = "map_marker_gray.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => {Navigation.PushAsync (new MainMapPage ());})
            });

            topMenuList.Add(new ToolbarItem {
                Text = "Settings",
                Icon = "bars_gray.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() =>  {})
            });

            #if ORIGINAL
            foreach (var item in topMenuList) {

                ContentView container = new ContentView ();
                ContentView view = new ContentView ();
                Image img = new Image ();
                img.Source = item.Icon;
                img.WidthRequest = 24;
                img.HeightRequest = 24;
                img.HorizontalOptions = LayoutOptions.EndAndExpand;
                img.VerticalOptions = LayoutOptions.CenterAndExpand;
                img.GestureRecognizers.Add (new TapGestureRecognizer (OnTapGestureRecognizerTapped));
                view.HorizontalOptions = LayoutOptions.EndAndExpand;
                view.VerticalOptions = LayoutOptions.CenterAndExpand;
                view.Padding = new Thickness (10,10,10,5);
                view.Content = img;
                container.Padding = new Thickness (0,17,0,5);
                container.HorizontalOptions = LayoutOptions.EndAndExpand;
                container.VerticalOptions = LayoutOptions.CenterAndExpand;
                container.Content = view;
                topMenu.Children.Add (container);

                toolbarItems.Add (img, item);        //  Hold on to toolbatitem so we can find it
            }
            #endif


            foreach (var item in topMenuList) {

                ContentView container = new ContentView ();
                ContentView view = new ContentView ();
                //ContentView view1 = new ContentView ();
                Image img = new Image ();
                img.Source = item.Icon;
                img.WidthRequest = 24;
                img.HeightRequest = 24;
                img.HorizontalOptions = LayoutOptions.EndAndExpand;
                img.VerticalOptions = LayoutOptions.CenterAndExpand;
                img.GestureRecognizers.Add (new TapGestureRecognizer (OnTapGestureRecognizerTapped));

                view.HorizontalOptions = LayoutOptions.EndAndExpand;
                view.VerticalOptions = LayoutOptions.CenterAndExpand;
                view.Padding = new Thickness (0, 0, 0, 0);

                RelativeLayout ss = new RelativeLayout ();
                //ss.Orientation = StackOrientation.Horizontal;
                Label lbl = new Label ();
                if (item.Text == "Wall")
                    lbl.Text = wallNewMessageCount.ToString ();
                if (item.Text == "Messages")
                    lbl.Text = newMessageCount.ToString ();
                lbl.WidthRequest = 10;
                lbl.HeightRequest = 10;
                lbl.XAlign = TextAlignment.Center;
                lbl.YAlign = TextAlignment.Center;
                //lbl.HorizontalOptions = LayoutOptions.CenterAndExpand;
                //lbl.VerticalOptions = LayoutOptions.CenterAndExpand;

                lbl.FontSize = 10;
                lbl.BackgroundColor = Color.FromRgb (41, 182, 246);

                //lbl.HorizontalOptions = LayoutOptions.EndAndExpand;
                //lbl.VerticalOptions = LayoutOptions.CenterAndExpand;
                //view1.Content = lbl;
                ss.Children.Add (img, 
                    Constraint.Constant (24), 
                    Constraint.Constant (24),
                    Constraint.RelativeToParent ((parent) => {
                        return 24;
                    }),
                    Constraint.RelativeToParent ((parent) => {
                        return 24;
                    }));
                if (item.Text == "Wall" || item.Text == "Messages") {
                    ss.Children.Add (lbl, 
                        Constraint.Constant (48), 
                        Constraint.Constant (24),
                        Constraint.RelativeToParent ((parent) => {
                            return 14;
                        }),
                        Constraint.RelativeToParent ((parent) => {
                            return 14;
                        }));
                }
                view.Content = ss;
                container.Padding = new Thickness (0, 0, 0, 5);
                container.HorizontalOptions = LayoutOptions.EndAndExpand;
                container.VerticalOptions = LayoutOptions.CenterAndExpand;
                container.Content = view;
                topMenu.Children.Add (container);
                toolbarItems.Add (img, item);        //  Hold on to toolbatitem so we can find it
            }



            topMenu.Spacing = 20;
            //topMenu.WidthRequest = 800;

            BoxView box = new BoxView { HeightRequest = 4, BackgroundColor = Color.FromRgb(41,182,246), HorizontalOptions = LayoutOptions.FillAndExpand };

            StackLayout layout = new StackLayout {
                BackgroundColor = Color.White,
                //WidthRequest = 800,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = {topMenu, box}
            };

            Content = layout;
            //_toolbar = this;

            // Display refresh icon while performing searches
            //MenuMasterPage.refreshToolbarItem = new ToolbarItem("Refresh", "ic_autorenew_black_24dp.png",  async () => {});
            //page.ToolbarItems.Add(refreshToolbarItem);
        }

        void OnTapGestureRecognizerTapped(View sender, Object o) {
            var img = (Image)sender;
            ContentView parent = (ContentView)img.ParentView.ParentView;
            ClearButtons();
            parent.BackgroundColor = Color.Red; 
            ToolbarItem item = toolbarItems [img];
            item.Command.Execute (null);
			parent.BackgroundColor = Color.Gray;
            //Console.WriteLine ("button click for: " + item.Text);

        }

        void ClearButtons()
        {
            foreach (var item in toolbarItems.Keys) {
                item.ParentView.BackgroundColor = Color.White;
            }

        }
    }
}

