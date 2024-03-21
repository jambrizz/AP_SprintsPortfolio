using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Travel.Models
{
    internal class ItenaryItem
    {
        [PrimaryKey, AutoIncrement]
        public int ItenaryItemID { get; set; }
        public int TravelPlanID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
