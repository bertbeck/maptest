using System;
using Xamarin.Forms;

//
//  This page allows a user to view and send messages.
//  Messages are displayed as a list ordered by member and time
//  Give user the ability to search messages
//
//  Prototype page
//

namespace maptest
{
    public class MessagesPage : ContentPage
    {
        public void MessagesPage_old ()
        {
            NavigationPage.SetHasNavigationBar(this, false);
			View toolbar = new Toolbar(this);

			var _header = new Label
			{
				Text = "   INBOX   ",
				FontSize = 20,
				FontFamily = "Helvetica Neue,Helvetica,Arial",
				XAlign = TextAlignment.Start,
				YAlign = TextAlignment.Center,
				WidthRequest = 2000,
				//HeightRequest = 40,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				BackgroundColor = Color.FromHex ("29B6F6"), 
				TextColor = Color.White,
			};

			var _newButton = new Button
			{
				Text = "New",
				VerticalOptions = LayoutOptions.FillAndExpand,
				TextColor = Color.White,
				//HeightRequest = 100
			};

			var newButton = new ContentView
			{
				Padding = new Thickness (0,0,0,0),
				Content = _newButton
			};



			StackLayout header = new StackLayout 
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0,-7,30,0),
				WidthRequest = 2000,
				BackgroundColor = Color.FromHex ("29B6F6"),
				Children = {_header, newButton}
			};

			var searchMessages = new Entry()
			{
				Keyboard = Keyboard.Chat,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Black,
				HeightRequest = 30,
				//Padding = new Thickness (5,0,0,0),
				Placeholder = "Search Messages"
			};




            Content = new StackLayout { 
				VerticalOptions = LayoutOptions.Start,
                Children = {
                    toolbar,
					header,
					searchMessages,
                    new Label { Text = "Messages" }
                }
            };
        }

		public MessagesPage ()
		{   NavigationPage.SetHasNavigationBar(this, false);
			View toolbar = new Toolbar (this);

			var _header = new Label {
				Text = "   INBOX   ",
				FontSize = 20,
				FontFamily = "Helvetica Neue,Helvetica,Arial",
				XAlign = TextAlignment.Start,
				YAlign = TextAlignment.Center,
				//WidthRequest = 2000,
				//	HeightRequest = 40,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex ("29B6F6"), 
				TextColor = Color.White,

			};

			var _newButton = new Button {
				Text = "New ",
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.Start,
				TextColor = Color.White,
				//WidthRequest = 150,
				BackgroundColor = Color.FromHex ("29B6F6"),

			};

			var newHeader = new ContentView {
				Padding = new Thickness (0, 0, 0, 0),
				Content = _header,

				//WidthRequest=2000
			};


			var newButton = new ContentView {
				//Padding = new Thickness (-10, 0, 10, 0),
				//HorizontalOptions = LayoutOptions.FillAndExpand,
				Content = _newButton,

				//WidthRequest=2000
			};

			var _box = new BoxView {
				BackgroundColor = Color.FromHex ("29B6F6"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				//WidthRequest = 2000
			};

			var box = new ContentView {
				//Padding = new Thickness (-20, 0, 0, 0),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Content = _box,
			};

			StackLayout header = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 0,
				Padding = new Thickness (0, -10, 0, 0),
				//WidthRequest = 2000,
				//HeightRequest = 40,
				//	BackgroundColor = Color.FromHex ("29B6F6"), 
				BackgroundColor = Color.Red,
				Children = { newHeader, newButton, box }
				//Children = {_header, _newButton, box}
			};

			var searchMessages = new Entry () {
				Keyboard = Keyboard.Chat,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Black,
				HeightRequest = 30,
				Placeholder = "Search Messages"
			};




			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					toolbar,
					header,
					searchMessages,
					new Label { Text = "Messages" }

				},

			};
		}


    } // Class
} // Namespace
