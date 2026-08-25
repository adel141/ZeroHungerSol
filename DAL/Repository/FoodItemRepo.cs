using DAL.EF;
using DAL.EF.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class FoodItemRepo
    {

        private readonly ZeroHungerContext db;
        public FoodItemRepo(ZeroHungerContext _db)
        {
            db = _db;
        }
        public List<FoodItem> GetAll()
        {
            return db.FoodItems.ToList();
        }
        public FoodItem GetById(int id)
        {
            var data = db.FoodItems.FirstOrDefault(r => r.Id == id);
            return data;
        }
        public void Add(FoodItem item)
        {
            db.FoodItems.Add(item);
            db.SaveChanges();
        }
        public bool Update(FoodItem item)
        {
            var data = db.FoodItems.FirstOrDefault(r => r.Id == item.Id);
            if (data != null)
            {
                data.Unit = item.Unit;
                data.Quantity = item.Quantity;
                data.FoodName = item.FoodName;
                data.RequestId = item.RequestId;
                
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var data = db.FoodItems.FirstOrDefault(r => r.Id == id);

            db.FoodItems.Remove(data);
            return db.SaveChanges() > 0;
        }

    }
}
