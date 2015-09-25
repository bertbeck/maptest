﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using System.Threading;
using Toasts.Forms.Plugin.Abstractions;

class Config {public bool Debug = false;}



namespace Test
{
    public class TestPage : ContentPage
    {

        public TestPage()
        {
            View toolbar = new maptest.Toolbar(this);
            SearchResults searchResults = new SearchResults ();

                var _header1 = new Label
                {
                    Text = "   FIND FRIENDS   ",
                    FontSize = 20,
                    FontFamily = "Helvetica Neue,Helvetica,Arial",
                    XAlign = TextAlignment.Start,
                    YAlign = TextAlignment.Center,
                WidthRequest = 1000,
                    HeightRequest = 40,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                    BackgroundColor = Color.FromHex ("39f"), 
                    TextColor = Color.White,
                };

            var _label1 = new Label
            {
                Text = "MUUV",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                FontFamily = "Helvetica Neue,Helvetica,Arial",
                HeightRequest = 40,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                //BackgroundColor = Color.FromHex ("39f"), 
                TextColor = Color.Green
            };

            var _label2 = new Label
            {
                Text = "Friends Nearby",
                FontSize = 18,
                FontFamily = "Helvetica Neue,Helvetica,Arial",
                HeightRequest = 40,
                XAlign = TextAlignment.Start,
                //BackgroundColor = Color.Black, 
                TextColor = Color.Black
            };


            StackLayout header1 = new StackLayout 
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex ("39f"),
                Padding = new Thickness(0,-5,0,0),
                Children = {_header1}
            };

            StackLayout header2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.White,
                Padding = new Thickness(25,0,0,0),
                Children = {_label1, _label2}
            };



                this.Content = new ContentView
                {
                    BackgroundColor = Color.White,
                //Padding = new Thickness (0,-5,0,0),
                    Content = new StackLayout
                    {
                        //BackgroundColor = new Color(200,200,200,1),
                        //HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Children = 
                        {
                            toolbar,
                            header1,
                            header2,
                            searchResults.View
                        }
                        }
                };
            }

        }
        

    public class SearchResults
    {
        public View View;
        static Image thumbsUp = null;
        static Image thumbsDown = null;

        public SearchResults ()
        {
            if (thumbsUp == null) {
                thumbsUp = new Image {WidthRequest=32, HeightRequest=32};
                thumbsUp.Source = "thumbsup.png";
                thumbsDown = new Image {WidthRequest=32, HeightRequest=32};
                thumbsDown.Source = "thumbsdown.png";
            }

            var News = new List<SearchResultsModel> ();
            News.Add (new SearchResultsModel {
                Title = "Title1",
                NewsURL = "www.ibm.com",
                MainImageURL = "http://testapp.letsmuuv.com/assets/img/users/user-3.jpg"
            });
            News.Add (new SearchResultsModel {
                Title = "Title2",
                NewsURL = "www.ibm.com",
                MainImageURL = "http://testapp.letsmuuv.com/assets/img/users/user-3.jpg"
            });
            News.Add (new SearchResultsModel {
                Title = "Title3",
                NewsURL = "www.ibm.com",
                MainImageURL = "http://testapp.letsmuuv.com/assets/img/users/user-3.jpg"
            });

            ListView listView = new ListView {
                // Source of data items.
                ItemsSource = News,
                HasUnevenRows = true,

                // Define template for displaying each item (Argument of DataTemplate constructor is called for each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate (() => {

                    // Create views with bindings for displaying each property.
                    Label titleLabel = new Label ();
                    titleLabel.SetBinding (Label.TextProperty, "Title");
                    titleLabel.FontSize = 16;
                    titleLabel.FontFamily = "Helvetica Neue,Helvetica,Arial";


                    Image picture = new Image();
                    picture.SetBinding (Image.SourceProperty, "MainImageURL");
                    picture.HeightRequest = 300;
                    picture.WidthRequest = 300;

                    var thumbs = new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {thumbsUp, thumbsDown}
                    };

                    return new ViewCell {
                        View = new StackLayout {
                            Padding = new Thickness (0),
                            Orientation = StackOrientation.Vertical,
                            Children = {
                                picture,
                                titleLabel,
                                thumbs
                            }
                        }
                    };
                })
            };

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

            // Build the page.
            this.View = listView;
            //this.View = new StackLayout {
            //Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5),
            //Children = {
            //  listView
            //}
            //};
        }
    }


    public class SearchResultsModel
    {
        public string Title { get; set; }
        public string NewsURL { get; set; }
        public string MainImageURL { get; set; }
    }

    class SearchResultItem
    {
        public string Text { get; set; }
        public string MessageTime { get; set; }
        public LayoutOptions HorizontalOptions { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
    }


}


