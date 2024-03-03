using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Inventory_Management_System
{
    public class Tally
    {
        public void RunApp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DisplyTitle();

            int selection = 0;
            bool validSelection = false;
            while (validSelection == false)
            {
                MainMenu();
                Console.WriteLine("Please select an option: ");
                string input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out selection);
                if (isNumber == false)
                {
                    Console.Clear();
                    Console.WriteLine($"Invalid selection, You entered {input}. please enter a number between 1 and 6");
                    Console.WriteLine();
                }
                else if (selection < 1 || selection > 6)
                {
                    Console.Clear();
                    Console.WriteLine($"Invalid selection, you entered {input}. please enter a number between 1 and 6");
                    Console.WriteLine();
                }
                else
                {
                    validSelection = true;
                }
            }

            switch (selection)
            {
                case 1:
                    Console.WriteLine("You selected option 1");
                    break;
                case 2:
                    Console.WriteLine("You selected option 2");
                    break;
                case 3:
                    Console.WriteLine("You selected option 3");
                    break;
                case 4:
                    Console.WriteLine("You selected option 4");
                    break;
                case 5:
                    Console.WriteLine("You selected option 5");
                    break;
                case 6:
                    Console.WriteLine("You selected option 6");
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }

        //This method displays the title of the application to the console
        private void DisplyTitle()
        {
            ConsoleText("Title.txt");
            Thread.Sleep(3000);
            LoadingMessage();
        }

        //This method displays a loading message to the console
        private void LoadingMessage()
        {
            Console.Clear();
            Console.CursorVisible = false;
            string message = "Loading";
            for (int i = 0; i < 4; i++)
            {
                Console.Write(message);
                System.Threading.Thread.Sleep(1000);
                message += ".";
                Console.Clear();
            }
            Console.CursorVisible = true;
        }

        //This method displays the main menu to the console
        private void MainMenu()
        {
            ConsoleText("Menu.txt");
        }

        //This method reads a text file and writes it to the console
        private void ConsoleText(string filename)
        {
            string path = "C:\\Users\\ambri\\OneDrive\\Documents\\BYU-I\\CSE 310 Applied Programming\\repo\\Sprint1\\Inventory_Management_System\\Inventory_Management_System\\";
            path += filename;
            
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            
        }
    }
}
