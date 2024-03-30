using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Models;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Itenaries : ContentPage
	{
        public Itenaries ()
		{
			InitializeComponent ();
            // Set the binding context to a new TravelPlan
			BindingContext = new TravelPlan();
		}

		protected override async void OnAppearing()
		{
            base.OnAppearing();

            // Get all travel plans
            CollectionView.ItemsSource = await App.Database.GetTravelPlansAsync();
        }

        // Retrieve Itenary
        async void Retrieve_Itenary(object sender, EventArgs e)
        {
            // Get the selected trip from the button
            var button = sender as Button;
            var travelPlan = button.CommandParameter as TravelPlan;

            if (travelPlan != null)
            {
                // Get the title and ID of the selected trip
                var title = travelPlan.Title;
                var travelPlanID = travelPlan.ID;

                // Set the selected trip ID
                DisplayTripItenary displayTripItenaryPage = new DisplayTripItenary();
                displayTripItenaryPage._selectedTripId = travelPlanID;

                // Navigate to DisplayTripItenary page
                await Navigation.PushModalAsync(displayTripItenaryPage);
            }
            else
            {
                await DisplayAlert("Error", "Failed to retrieve TravelPlan.", "OK");
            }
        }

        // Delete Itenary
        async void Delete_Clicked(object sender, EventArgs e)
		{
            var button = sender as Button;
            var travelPlan = button.BindingContext as TravelPlan;

            // Delete the selected travel plan
            await App.Database.DeleteTravelPlanAsync(travelPlan);
            // Refresh the page
            CollectionView.ItemsSource = await App.Database.GetTravelPlansAsync();
        }

        // Navigate to Home
		private async void Home_Clicked(object sender, EventArgs e)
		{
            await Navigation.PopModalAsync();
        }

    }
}