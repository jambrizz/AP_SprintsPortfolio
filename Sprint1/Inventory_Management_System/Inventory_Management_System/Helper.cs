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
        protected string root = "C:\\Users\\ambri\\OneDrive\\Documents\\BYU-I\\CSE 310 Applied Programming\\repo\\Sprint1\\Inventory_Management_System\\Inventory_Management_System\\";
        protected string FileName = "Inventory.json";
        protected List<string> jsonObjects = new List<string>();

        // Method to display all items in the JSON file
        public void DisplayAllItems()
        {
            string path = root + FileName;
            foreach (string line in File.ReadAllLines(path))
            {
               string newLine = RemoveJSONSyntax(line);
               
               if(newLine != null)
               {
                    Console.WriteLine(newLine);
                    Console.WriteLine();
               }
            }
        }

        // Method to display all items in the JSON file to a List and each item is numbered and displayed to the console
        public void DisplayItemToSelect()
        { 
            string path = root + FileName;
            int count = 1;
            
            AddJSONObjectsToList();

            foreach (string item in jsonObjects)
            {
                string newLine = RemoveJSONSyntax(item);
                Console.WriteLine(count + ". " + newLine);
                count++;
            }
            ClearList();
        }

        public void ClearList()
        {
            jsonObjects.Clear();
        }

        // Method to add all valid JSON objects to a list
        private void AddJSONObjectsToList()
        {
            string path = root + FileName;
            foreach (string line in File.ReadAllLines(path))
            {
                string item = IsThisAJSONObj(line);

                if (item != null)
                {
                    jsonObjects.Add(item);
                }
            }
        }

        // Method to remove a JSON object from the JSON file
        public void RemoveJSONObj(int selection)
        { 
            AddJSONObjectsToList();
            
            int selectionIndex = selection - 1;
            jsonObjects.RemoveAt(selectionIndex);

            WriteListToFile();
        }

        // Method is to return a JSON object from the JSON file
        public string GetJSONObj(int selection)
        {
            string line = "";
            AddJSONObjectsToList();
            int selectionIndex = selection - 1;
            line = jsonObjects[selectionIndex];
            ClearList();
            return line;
        }

        // Method to write the list of JSON objects to a JSON file
        private void WriteListToFile()
        {
            string path = root + FileName;
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("{");
                sw.WriteLine("\"items\":[");
                sw.WriteLine(string.Join("," + Environment.NewLine, jsonObjects));
                sw.WriteLine("]");
                sw.WriteLine("}");
            }
        }

        // Method to save an item JSON string to a JSONfile
        public void SaveToFile(string json)
        {            
            string path = root + FileName;

            if (!File.Exists(path))
            {
                //File.AppendAllText(path, json);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("{");
                    sw.WriteLine("\"items\":[");
                    sw.WriteLine(json);
                    sw.WriteLine("]");
                    sw.WriteLine("}");
                }
            }
            else
            {
                // Read existing lines from JSON file and add valid JSON objects to the list
                foreach (string line in File.ReadAllLines(path))
                {
                    if (line != "{" && line != "\"items\":[" && line != "]" && line != "}")
                    { 
                        string newLine = RemoveLastComma(line);
                        jsonObjects.Add(newLine);
                    }
                }

                // Add the new JSON string to the list of objects
                jsonObjects.Add(json);

                //using streamwriter to write to the json file
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("{");
                    sw.WriteLine("\"items\":[");
                    sw.WriteLine(string.Join("," + Environment.NewLine, jsonObjects));
                    sw.WriteLine("]");
                    sw.WriteLine("}");
                }
            }
        }

        // Helper method to remove the last comma from a json object
        private string RemoveLastComma(string input)
        {
            string newLine = "";
            int lastChar = input.Length - 1;
            if (input[lastChar] == ',')
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    newLine += input[i];
                }
            }
            else
            {
                newLine = input;
            }
            return newLine;
        }

        // Helper method to remove the JSON syntax from a line and return a string
        private string RemoveJSONSyntax(string line)
        { 
            string newLine = "";
            if (line != "{" && line != "\"items\":[" && line != "]" && line != "}")
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != '{' && line[i] != '}' && line[i] != '[' && line[i] != ']' && line[i] != '\"')
                    {
                        newLine += line[i];
                    }
                }
            }
            return newLine;
        }

        // Helper method to add a JSON object to a list of JSON objects
        private string IsThisAJSONObj(string line)
        {
            string newLine = "";
            if (line != "{" && line != "\"items\":[" && line != "]" && line != "}")
            {
                newLine = RemoveLastComma(line);
            }
            else
            { 
                newLine = null;
            }

            return newLine;
        }

    }
}
