using System;
using Travel.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travel.Data;
using System.IO;
using SQLite;

namespace Travel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trip : ContentPage
	{
		public Trip ()
		{
			InitializeComponent ();
            BindingContext = new TravelPlan();
        }

		private async void SaveTrip(object sender, EventArgs e)
		{
            var trip = (TravelPlan)BindingContext;

            // Check if trip is null
            if (trip == null)
            {
                await DisplayAlert("Alert", "Trip is null", "OK");
                return;
            }

            trip.Title = TripName.Text;
            trip.StartDate = startDate?.Date ?? DateTime.MinValue; // Null propagation and null coalescing operators used to handle potential null references
            trip.EndDate = endDate?.Date ?? DateTime.MinValue;

            if (!string.IsNullOrWhiteSpace(trip.Title))
            {
                if (App.Database != null)
                {
                    await App.Database.SaveTravelPlanAsync(trip);
                }
                else
                {
                    await DisplayAlert("Alert", "Database is null", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Please enter a title", "OK");
            }

            await Navigation.PopModalAsync();
            
        }

		public void CancelEntry(object sender, EventArgs e)
		{
            
        }

		/*
		protected override async void OnAppearing()
		{
            base.OnAppearing();
            CollectionView.ItemsSource = await App.Database.GetTravelPlansAsync();
        }
		*/
	}
}