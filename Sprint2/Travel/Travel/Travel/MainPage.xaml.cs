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
        }
        
        void OnButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Button was clicked", "OK");
        }

        async  void NewItenary(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.Add());
        }

        void LoadItenary(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new LoadItenary());
            DisplayAlert("Alert", "Load an itenary", "OK");
        }

    }
}
