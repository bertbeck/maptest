using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Collections.ObjectModel;
namespace maptest
{
	public partial class SwipeToDelete : ContentPage
	{
		//ObservableCollection<string> items;

		List<ClsProfileData> items=new List<ClsProfileData>();
		public SwipeToDelete ()
		{
			InitializeComponent ();		
		//	items = new ObservableCollection<string> { "Parag", "Pankaj", "Bert", "Sarang", "Paresh","Suresh","Trushant","Prashant" };
			items.Add(new ClsProfileData(){Name="George Washington",Images="http://www.americanpresidents.org/images/01_150.gif"});
			items.Add(new ClsProfileData(){Name="John Adams",Images="http://www.americanpresidents.org/images/02_150.gif"});
			items.Add(new ClsProfileData(){Name="Thomas  Jefferson",Images= "http://www.americanpresidents.org/images/03_150.gif"});
			items.Add(new ClsProfileData(){Name="James Madison",Images="http://www.americanpresidents.org/images/04_150.gif"});
			items.Add(new ClsProfileData(){Name="James Monroe",Images="http://www.americanpresidents.org/images/05_150.gif"});
			items.Add(new ClsProfileData(){Name="John Quincy Adams",Images= "http://www.americanpresidents.org/images/06_150.gif"});

			items.Add(new ClsProfileData(){Name="Andrew Jackson",Images="http://www.americanpresidents.org/images/07_150.gif"});
			items.Add(new ClsProfileData(){Name="Martin Van Buren",Images="http://www.americanpresidents.org/images/08_150.gif"});
			items.Add(new ClsProfileData(){Name="William Henry Harrison",Images= "http://www.americanpresidents.org/images/09_150.gif"});

			items.Add(new ClsProfileData(){Name="John Tyler",Images="http://www.americanpresidents.org/images/10_150.gif"});
			items.Add(new ClsProfileData(){Name="James K. Polk",Images="http://www.americanpresidents.org/images/11_150.gif"});
			items.Add(new ClsProfileData(){Name="Zachary Taylor",Images= "http://www.americanpresidents.org/images/12_150.gif"});

			items.Add(new ClsProfileData(){Name="Millard Fillmore",Images="http://www.americanpresidents.org/images/13_150.gif"});
			items.Add(new ClsProfileData(){Name="Franklin Pierce",Images="http://www.americanpresidents.org/images/14_150.gif"});
			items.Add(new ClsProfileData(){Name="James Buchanan",Images= "http://www.americanpresidents.org/images/15_150.gif"});


//			items.Add(new ClsProfileData(){});
//			items.Add(new ClsProfileData(){});
//			items.Add(new ClsProfileData(){});
		listView.SetBinding (ListView.ItemsSourceProperty, new Binding ("."));
			listView.BindingContext = items;

			//listView.ItemsSource = items;
		}

		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
			DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
			((ListView)sender).SelectedItem = null; // de-select the row
		}

		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");

			Debug.WriteLine ("delete " + mi.CommandParameter.ToString ());
		//	items.Remove (mi.CommandParameter.ToString());
		}

	}
}



