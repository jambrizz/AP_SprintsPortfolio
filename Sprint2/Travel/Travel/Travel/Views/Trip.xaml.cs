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
            /*
            var trip = (TravelPlan)BindingContext;
            //var trip = new Models.TravelPlan();
            //trip.ID = id;
            trip.Title = TripName.Text;
            trip.StartDate = startDate.Date;
            trip.EndDate = endDate.Date;

            if (trip != null && !string.IsNullOrWhiteSpace(trip.Title))
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
                if(trip == null)
				{
                    await DisplayAlert("Alert", "Trip is null", "OK");
                }
                else
				{
                    await DisplayAlert("Alert", "Please enter a title", "OK");
                }
            }

			await Navigation.PopModalAsync();

			
			var trip = (TravelPlan)BindingContext;
			if(!string.IsNullOrWhiteSpace(trip.Title))
			{
                await App.Database.SaveTravelPlanAsync(trip);
            }

			await Navigation.PopModalAsync();
			////////////////////////////////////////
			TravelPlan t = new TravelPlan();
			int id = t.GetID();
			
			var trip = new Models.TravelPlan();
			trip.ID = id;
			trip.Title = TripName.Text;
			trip.StartDate = startDate.Date;
			trip.EndDate = endDate.Date;

			if (trip.Title == null || trip.Title == "")
			{
				await DisplayAlert("Alert", "Please enter a title", "OK");
			}
			else
			{
                await DisplayAlert("Alert", $"{trip.ID}, {trip.Title} {trip.StartDate.ToShortDateString()}, {trip.EndDate.ToShortDateString()}", "OK");
				//await App.Database.SaveTravelPlanAsync(trip);
            }
			*/
        }

		public void CancelEntry(object sender, EventArgs e)
		{
            //await Navigation.PopModalAsync();
			//await Navigation.PopModalAsync(new Travel.MainPage());
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