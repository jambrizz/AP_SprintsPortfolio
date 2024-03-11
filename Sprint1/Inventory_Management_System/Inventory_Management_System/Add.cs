using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Inventory_Management_System
{
    internal class Add
    {
        string ItemId { get; set; }
        string ItemName { get; set; }
        string ItemDescription { get; set; }
        double ItemPrice { get; set; }
        int ItemQuantity { get; set; }

        DateTime Date { get; set; }
        
        //This method is to add a new item to the inventory
        public void AddItem()
        {
            Console.WriteLine("Please enter the item ID: ");
            ItemId = Console.ReadLine();
            Console.WriteLine("Please enter the item name: ");
            ItemName = Console.ReadLine();
            Console.WriteLine("Please enter the item description: ");
            ItemDescription = Console.ReadLine();
            Console.WriteLine("Please enter the item price: ");
            ItemPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the item quantity: ");
            ItemQuantity = Convert.ToInt32(Console.ReadLine());
            Date = DateTime.Now;

            //This calls a new instance of the Item class and assigns the values to the properties
            var newItem = new Item
            {
                Id = ItemId,
                Name = ItemName,
                Description = ItemDescription,
                Price = ItemPrice,
                Quantity = ItemQuantity,
                DateAdded = Date
            };

            //This is to convert the item to a json string
            var json = JsonConvert.SerializeObject(newItem);
            Helper h = new Helper();
            h.SaveToFile(json);
        }

        // Method to split the json objects and distribute them to the properties of the Item class
        private void SplitJson(string json)
        {
            var item = JsonConvert.DeserializeObject<Item>(json);
            ItemId = item.Id;
            ItemName = item.Name;
            ItemDescription = item.Description;
            ItemPrice = item.Price;
            ItemQuantity = item.Quantity;
            Date = item.DateAdded;
        }

        // Method is to update the item details
        public void UpdateItem(string line)
        {
            SplitJson(line);

            bool keepUpdating = true;
            while (keepUpdating == true)
            {
                Console.Clear();
                Console.WriteLine("***********************************");
                Console.WriteLine("Please select the field to update: ");
                Console.WriteLine();
                Console.WriteLine($"1. Item ID: {ItemId}");
                Console.WriteLine($"2. Item Name: {ItemName}");
                Console.WriteLine($"3. Item Description: {ItemDescription}");
                Console.WriteLine($"4. Item Price: {ItemPrice}");
                Console.WriteLine($"5. Item Quantity: {ItemQuantity}");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.WriteLine("***********************************");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                string input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out int selection);
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
                    switch (selection)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Please enter the item ID: ");
                            ItemId = Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Please enter the item name: ");
                            ItemName = Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Please enter the item description: ");
                            ItemDescription = Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Please enter the item price: ");
                            ItemPrice = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Please enter the item quantity: ");
                            ItemQuantity = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 6:
                            keepUpdating = false;
                            break;
                    }
                }   
            }

            var newItem = new Item
            {
                Id = ItemId,
                Name = ItemName,
                Description = ItemDescription,
                Price = ItemPrice,
                Quantity = ItemQuantity,
                DateAdded = DateTime.Now
            };

            var json = JsonConvert.SerializeObject(newItem);
            Helper h = new Helper();
            h.SaveToFile(json);
        }
    }

    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
