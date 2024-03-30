using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Travel.Models;
using Xamarin.Essentials;

namespace Travel.Data
{
    class ItenaryDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItenaryDatabase(string dbPath)
        {
            try
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<ItenaryItem>().Wait();
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine("Error creating database tables: " + ex.Message);
                throw; // Rethrow the exception to propagate it up the call stack
            }
        }

        private SQLiteAsyncConnection GetConnection()
        {
            var databaseName = "ItenaryItems.db3";
            var documentsPath = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(documentsPath, databaseName);
            return new SQLiteAsyncConnection(databasePath);
        }

        // Get all itenary items.
        public Task<List<ItenaryItem>> GetItenaryItemsAsync()
        {
            //Get all itenary items.
            return database.Table<ItenaryItem>().ToListAsync();
        }

        // Get all itenary items for a specific trip.
        public Task<List<ItenaryItem>> GetAllItenaryItemsByTrip(int travelPlanID)
        {
            //Get all itenary items for a specific trip.
            return database.Table<ItenaryItem>()
                            .Where(i => i.TravelPlanID == travelPlanID)
                            .ToListAsync();
        }

        // Get a specific itenary item based on the ID.
        public Task<ItenaryItem> GetItenaryItemAsync(int id)
        {
            //Get a specific itenary item.
            return database.Table<ItenaryItem>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        // Save an itenary item.
        public Task<int> SaveItenaryItemAsync(ItenaryItem itenaryItem)
        {
            if (itenaryItem.ID != 0)
            {
                // Update an existing itenary item.
                return database.UpdateAsync(itenaryItem);
            }
            else
            {
                // Save a new itenary item.
                return database.InsertAsync(itenaryItem);
            }
        }

        // Delete an itenary item.
        public Task<int> DeleteItenaryItemAsync(ItenaryItem itenaryItem)
        {
            // Delete an itenary item.
            return database.DeleteAsync(itenaryItem);
        }

    }
}
