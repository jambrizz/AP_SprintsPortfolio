using System;
using System.IO;
using Travel.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travel.Models;

namespace Travel
{
    public partial class App : Application
    {
        static TravelDatabase database;
        
        public static TravelDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TravelDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TravelPlans.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
