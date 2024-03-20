using System.ComponentModel;
using Travel_Planner_App.ViewModels;
using Xamarin.Forms;

namespace Travel_Planner_App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}