using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travel.Models;
using System.IO;
using Xamarin.Essentials;


namespace Travel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        public Add()
        {
            InitializeComponent();
            //BindingContext = new TravelPlan();
            BindingContext = new TravelPlan();
            //BindingContext = new ItenaryItem();
            BindingContext = new ItenaryItem();

            //This is to populate the picker with the trip names
            var TripListName = new List<string>();
            foreach (var trip in App.Database.GetTravelPlansAsync().Result)
            {
                TripListName.Add(trip.Title);
            }

            TripPicker.ItemsSource = TripListName;
            
        }

        //This is to save the itenary item
        private async void SaveItenary(object sender, EventArgs e)
        {
            var itenary = (ItenaryItem)BindingContext;
            
            if (itenary == null)
            {
                await DisplayAlert("Alert", "Itenary is null", "OK");
                return;
            }
            //This is to get the travel plan ID from the selected trip name
            itenary.TravelPlanID = App.Database.ReturnTravelPlanID(TripPicker.SelectedItem.ToString());
            itenary.Title = EventName.Text;
            itenary.Description = Description.Text;
            itenary.EventDate = EventDate.Date;
            itenary.StartTime = StartTime.Time;
            itenary.EndTime = EndTime.Time;

            if (!string.IsNullOrWhiteSpace(itenary.Title))
            {
                //This is to switch between the two databases for the itenary items.
                var itenaryDatabase = new ItenaryDatabase(Path.Combine(FileSystem.AppDataDirectory, "ItenaryItems.db3"));
                if (App.Database != null)
                {
                    await itenaryDatabase.SaveItenaryItemAsync(itenary);

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

        //This is to cancel the itenary item
        //And return to the previous page
        private async void CancelItenary(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}