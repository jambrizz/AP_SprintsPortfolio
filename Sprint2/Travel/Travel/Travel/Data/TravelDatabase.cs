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
    public class TravelDatabase
    {
        readonly SQLiteAsyncConnection database;

        

        public TravelDatabase(string dbPath)
        {
            try
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<TravelPlan>().Wait();
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
            var databaseName = "TravelPlans.db3";
            var documentsPath = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(documentsPath, databaseName);
            return new SQLiteAsyncConnection(databasePath);
        }

        public Task<List<TravelPlan>> GetTravelPlansAsync()
        {
            //Get all travel plans.
            return database.Table<TravelPlan>().ToListAsync();
        }

        public Task<TravelPlan> GetTravelPlanAsync(int id)
        {
            //Get a specific travel plan.
            return database.Table<TravelPlan>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public int ReturnTravelPlanID(string title)
        {
            int id = 0;
            var trip = database.Table<TravelPlan>()
                .Where(i => i.Title == title)
                .FirstOrDefaultAsync();
            if (trip != null)
            {
                id = trip.Result.ID;
            }
            return id;
        }

        public Task<int> SaveTravelPlanAsync(TravelPlan travelPlan)
        {
            if (travelPlan.ID != 0)
            {
                //Update an existing travel plan.
                return database.UpdateAsync(travelPlan);
            }
            else
            {
                //Insert a new travel plan.
                return database.InsertAsync(travelPlan);
            }
        }

        public Task<int> DeleteTravelPlanAsync(TravelPlan travelPlan)
        {
            //Delete a travel plan.
            return database.DeleteAsync(travelPlan);
        }

    }
}
