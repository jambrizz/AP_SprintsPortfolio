using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trip : ContentPage
	{
		public Trip ()
		{
			InitializeComponent ();
		}

		private async void SaveTrip(object sender, EventArgs e)
		{
			var trip = (Models.TravelPlan)BindingContext;
			if (!string.IsNullOrEmpty(trip.Title))
			{
                //Models.TravelPlan.AddTravelPlan(trip);
                //this.Navigation.PopAsync();
				await App.Database.SaveTravelPlanAsync(trip);
            }
			else
			{
                await DisplayAlert("Error", "Please enter a title.", "OK");
            }

			await Shell.Current.GoToAsync("..");
			/*
            Models.TravelPlan travelPlan = new Models.TravelPlan()
			{
                Title = TripName.Text,
                StartDate = StartDate.Date,
                EndDate = EndDate.Date
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
			{
                conn.CreateTable<Models.TravelPlan>();
                int rowsAdded = conn.Insert(travelPlan);
            }
			*/
        }

		public void CancelEntry(object sender, EventArgs e)
		{
            //await Navigation.PopModalAsync();
			//await Navigation.PopModalAsync(new Travel.MainPage());
        }
	}
}