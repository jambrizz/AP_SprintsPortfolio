using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Inventory_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
           Tally tally = new Tally();
            tally.RunApp();
        }
    }
}
