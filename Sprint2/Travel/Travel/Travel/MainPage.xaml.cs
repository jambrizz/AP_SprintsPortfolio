﻿using System;
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

        void NewItenary(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Create new itenary", "OK");
            //Navigation.PushAsync(new Page);
        }

        void LoadItenary(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new LoadItenary());
            DisplayAlert("Alert", "Load an itenary", "OK");
        }

    }
}