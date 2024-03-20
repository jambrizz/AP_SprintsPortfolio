using System;
using System.Collections.Generic;
using System.ComponentModel;
using Travel_Planner_App.Models;
using Travel_Planner_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travel_Planner_App.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}