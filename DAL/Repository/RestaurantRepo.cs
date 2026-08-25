using DAL.EF;
using DAL.EF.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class RestaurantRepo
    {
        private readonly ZeroHungerContext db;
        public RestaurantRepo(ZeroHungerContext _db)
        {
            db = _db;
        }
        public List<Restaurant> GetAll()
        {
            return db.Restaurants.ToList();
        }
        public Restaurant GetById(int id)
        {
            var data = db.Restaurants.FirstOrDefault(r => r.Id == id);
            return data;
        }
        public void Add(Restaurant item) {
            db.Restaurants.Add(item);
            db.SaveChanges();
        }
        public bool Update(Restaurant item)
        {
            var data = db.Restaurants.FirstOrDefault(r => r.Id == item.Id);
            if (data != null)
            {
                data.RestaurantName = item.RestaurantName;
                data.Address = item.Address;
                data.PhoneNumber = item.PhoneNumber;
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var data = db.Restaurants.FirstOrDefault(r => r.Id == id);
           
            db.Restaurants.Remove(data);
            return db.SaveChanges() > 0;
        }


        public List<FoodCollectionRequest> GetFoodCollectionRequestsByRestaurantId(int restaurantId)
        {
            return db.FoodCollectionRequests
                .Where(x => x.RestaurantId == restaurantId)
                .Include(x => x.Restaurant)
                .Include(x => x.FoodItems)
                .ToList();
        }

    }
}
