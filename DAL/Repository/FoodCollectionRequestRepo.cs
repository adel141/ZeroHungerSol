using DAL.EF;
using DAL.EF.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class FoodCollectionRequestRepo
    {
        
        private readonly ZeroHungerContext db;
        public FoodCollectionRequestRepo(ZeroHungerContext _db)
        {
            db = _db;
        }
        public List<FoodCollectionRequest> GetAll()
        {
            return db.FoodCollectionRequests.ToList();
        }
        public FoodCollectionRequest GetById(int id)
        {
            var data = db.FoodCollectionRequests.FirstOrDefault(r => r.Id == id);
            return data;
        }
        public void Add(FoodCollectionRequest item)
        {
            db.FoodCollectionRequests.Add(item);
            db.SaveChanges();
        }
        public bool Update(FoodCollectionRequest item)
        {
            var data = db.FoodCollectionRequests.FirstOrDefault(r => r.Id == item.Id);
            if (data != null)
            {
                data.RestaurantId = item.RestaurantId;
                data.RequestDate = item.RequestDate;
                data.PreservationDeadline = item.PreservationDeadline;
                data.Status = item.Status;
                data.FoodItems = item.FoodItems;

                return db.SaveChanges() > 0;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var data = db.FoodCollectionRequests.FirstOrDefault(r => r.Id == id);

            db.FoodCollectionRequests.Remove(data);
            return db.SaveChanges() > 0;
        }

    }
}
