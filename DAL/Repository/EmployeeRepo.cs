using DAL.EF;
using DAL.EF.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRepo
    {
        private readonly ZeroHungerContext db;
        public EmployeeRepo(ZeroHungerContext _db)
        {
            db = _db;
        }
        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            var data = db.Employees.FirstOrDefault(r => r.Id == id);
            return data;
        }
        public void Add(Employee item)
        {
            db.Employees.Add(item);
            db.SaveChanges();
        }
        public bool Update(Employee item)
        {
            var data = db.Employees.FirstOrDefault(r => r.Id == item.Id);
            if (data != null)
            {
                data.FullName = item.FullName;
                data.PhoneNumber = item.PhoneNumber;
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var data = db.Employees.FirstOrDefault(r => r.Id == id);

            db.Employees.Remove(data);
            return db.SaveChanges() > 0;
        }

    }
}
