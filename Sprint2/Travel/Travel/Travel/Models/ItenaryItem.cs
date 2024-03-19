using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Models
{
    internal class ItenaryItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
