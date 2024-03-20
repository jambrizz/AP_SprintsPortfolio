using System;
using Travel_Planner_App.Services;
using Travel_Planner_App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travel_Planner_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
