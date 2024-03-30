using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travel.Data;
using System.IO;
using Xamarin.Essentials;

namespace Travel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisplayTripItenary : ContentPage
	{
		public int _selectedTripId;

        public DisplayTripItenary ()
		{
			InitializeComponent ();
			//bindingContext is set to ItenaryItem
			BindingContext = new ItenaryItem();
		}

		//OnAppearing is called when the page is navigated to
		protected override void OnAppearing()
		{
            base.OnAppearing();

			//load the itenary items for the selected trip
			OnLoad(_selectedTripId);
        }
		
		//OnLoad is called when the page is navigated to and loads the itenary items for the selected trip using the trip id
		public void OnLoad(int id)
		{
            var itenaryDatabase = new ItenaryDatabase(Path.Combine(FileSystem.AppDataDirectory, "ItenaryItems.db3"));
            var itenaryItems = itenaryDatabase.GetAllItenaryItemsByTrip(id).Result;

			//sort the itenary items by date and then time
            itenaryItems = itenaryItems.OrderBy(i => i.EventDate).ThenBy(i => i.StartTime).ToList();

            CollectionView.ItemsSource = itenaryItems;
        }

		//This method retrieves the event description when the description button is clicked and displays it in an alert
		async void Description_Clicked(object sender, EventArgs e)
		{
            var button = sender as Button;
            var itenaryItem = button.BindingContext as ItenaryItem;

            if (itenaryItem != null)
			{
                await DisplayAlert("Description", itenaryItem.Description, "OK");
            }
            else
			{
                await DisplayAlert("Error", "Failed to retrieve ItenaryItem.", "OK");
            }
        }

		//This method deletes the itenary item when the delete button is clicked
		async void Delete_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			var itenaryItem = button.BindingContext as ItenaryItem;
			var itenaryDatabase = new ItenaryDatabase(Path.Combine(FileSystem.AppDataDirectory, "ItenaryItems.db3"));
			await itenaryDatabase.DeleteItenaryItemAsync(itenaryItem);
			OnLoad(_selectedTripId);
		}
		
		//This method navigates back to the itenary page when the return button is clicked
		async void Return_Trips(object sender, EventArgs e)
		{
            await Navigation.PushModalAsync(new Views.Itenaries());
        }

		//This method navigates back to the home page when the return button is clicked
		private async void Return_Home(object sender, EventArgs e)
		{ 
			//await Navigation.PopModalAsync();
			await Navigation.PushModalAsync(new MainPage());
		}
	}
}