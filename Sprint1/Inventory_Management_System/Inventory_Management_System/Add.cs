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
