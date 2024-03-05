using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Inventory_Management_System
{
    internal class Helper
    {
        //TODO: This method works but it overwrites the file each time a new item is added.
        public void SaveToFile(string json)
        {
            string root = "C:\\Users\\ambri\\OneDrive\\Documents\\BYU-I\\CSE 310 Applied Programming\\repo\\Sprint1\\Inventory_Management_System\\Inventory_Management_System\\";
            string FileName = "Inventory.json";
            string path = root + FileName;

            if (!File.Exists(path))
            {
                File.Create(path);
                File.WriteAllText(path, json);
            }
            else
            {
                File.WriteAllText(path, json);
            }


        }
    }
}
