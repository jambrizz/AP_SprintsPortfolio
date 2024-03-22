using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Travel.Models;

namespace Travel.Data
{
    public class TravelDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TravelDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Models.TravelPlan>().Wait();
            database.CreateTableAsync<Models.ItenaryItem>().Wait();
        }

        public Task<List<TravelPlan>> GetTravelPlansAsync()
        {
            //Get all travel plans.
            return database.Table<Models.TravelPlan>().ToListAsync();
        }

        public Task<TravelPlan> GetTravelPlanAsync(int id)
        {
            //Get a specific travel plan.
            return database.Table<Models.TravelPlan>()
                            .Where(i => i.TravelPlanID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTravelPlanAsync(TravelPlan travelPlan)
        {
            if (travelPlan.TravelPlanID != 0)
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
