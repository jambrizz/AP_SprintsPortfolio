using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Inventory_Management_System
{
    internal class Helper
    {
        
        //private List<string> strings = new List<string>();
        //TODO: This method works but it overwrites the file each time a new item is added.
        public void SaveToFile(string json)
        {
            // Create a list to store the JSON objects
            List<string> jsonObjects = new List<string>();
            string root = "C:\\Users\\ambri\\OneDrive\\Documents\\BYU-I\\CSE 310 Applied Programming\\repo\\Sprint1\\Inventory_Management_System\\Inventory_Management_System\\";
            string FileName = "Inventory.json";
            string path = root + FileName;

            if (!File.Exists(path))
            {
                //File.AppendAllText(path, json);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("{");
                    sw.WriteLine(json);
                    sw.WriteLine("}");
                }
            }
            else
            {
                //TODO: fix this else statement so it starts with a bracket and ends with a bracket
                // Add the new JSON string to the list of objects
                jsonObjects.Add(json);

                // Read existing lines from JSON file and add valid JSON objects to the list
                foreach (string line in File.ReadAllLines(path))
                {
                    if (IsValidJsonObject(line))
                    {
                        jsonObjects.Add(line.Trim());
                    }
                }

                // Write the list of JSON objects back to the file, separating them with commas
                File.WriteAllText(path, string.Join("," + Environment.NewLine, jsonObjects) + Environment.NewLine);
            }
        }

        // Helper method to check if a line represents a valid JSON object
        private bool IsValidJsonObject(string input)
        {
            input = input.Trim();
            return (input.StartsWith("{") && input.EndsWith("}")) || // For an object
                   (input.StartsWith("[") && input.EndsWith("]"));   // For an array
        }
        
    }
}
