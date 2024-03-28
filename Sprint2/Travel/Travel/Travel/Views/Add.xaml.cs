using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travel.Models;


namespace Travel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        public Add()
        {
            InitializeComponent();
            BindingContext = new TravelPlan();
            BindingContext = new ItenaryItem();
        }

        /*
        private async void SaveItenary(object sender, EventArgs e)
        {
            var itenary = (ItenaryItem)BindingContext;

            // Check if itenary is null
            if (itenary == null)
            {
                await DisplayAlert("Alert", "Itenary is null", "OK");
                return;
            }

            itenary.Title = ItenaryTitle.Text;
            itenary.Description = ItenaryDescription.Text;
            itenary.EventDate = EventDate.Date;
            itenary.StartTime = StartTime.Time;
            itenary.EndTime = EndTime.Time;

            if (!string.IsNullOrWhiteSpace(itenary.Title))
            {
                if (App.Database != null)
                {
                    await App.Database.SaveItenaryItemAsync(itenary);
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
        */
        private async void CancelItenary(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}