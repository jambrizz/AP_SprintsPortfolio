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
			BindingContext = new TravelPlan();
		}

		protected override async void OnAppearing()
		{
            base.OnAppearing();

            // Get all travel plans
            CollectionView.ItemsSource = await App.Database.GetTravelPlansAsync();
        }

		async void Delete_Clicked(object sender, EventArgs e)
		{
            var button = sender as Button;
            var travelPlan = button.BindingContext as TravelPlan;
            await App.Database.DeleteTravelPlanAsync(travelPlan);
            CollectionView.ItemsSource = await App.Database.GetTravelPlansAsync();
        }

		private async void Home_Clicked(object sender, EventArgs e)
		{
            await Navigation.PopModalAsync();
        }

    }
}