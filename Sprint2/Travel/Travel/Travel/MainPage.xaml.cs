using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Travel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Routing.RegisterRoute("trip", typeof(Views.Trip));
        }

        //This is to navigate to the trip page
        async void NewTrip(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Trip());
        }

        //This is to navigate to the add an itenary event page
        async  void NewItenary(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Add());
        }

        //This is to navigate to the itenary page
        async void LoadItenary(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Itenaries());
        }

    }
}
