using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Travel.Models
{
    public class ItenaryItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int TravelPlanID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
