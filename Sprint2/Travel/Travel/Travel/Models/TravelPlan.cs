using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Travel.Models
{
    public class TravelPlan
    {
        [PrimaryKey, AutoIncrement]
        public int TravelPlanID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

       
        public async void AddTravelPlan(TravelPlan travelPlan)
        {
            await App.Database.SaveTravelPlanAsync(travelPlan);
        }
    }
}
