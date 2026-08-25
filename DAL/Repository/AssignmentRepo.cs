using DAL.EF;
using DAL.EF.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class AssignmentRepo
    {
        
        private readonly ZeroHungerContext db;
        public AssignmentRepo(ZeroHungerContext _db)
        {
            db = _db;
        }
        public List<Assignment> GetAll()
        {
            return db.Assignments.ToList();
        }
        public Assignment GetById(int id)
        {
            var data = db.Assignments.FirstOrDefault(r => r.Id == id);
            return data;
        }
        public void Add(Assignment item)
        {
            db.Assignments.Add(item);
            db.SaveChanges();
        }
        public bool Update(Assignment item)
        {
            var data = db.Assignments.FirstOrDefault(r => r.Id == item.Id);
            if (data != null)
            {
                db.Update(item);
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public List<Assignment> GetByEmployeeId(int employeeId)
        {
            return db.Assignments
                .Where(x => x.EmployeeId == employeeId)
                .Include(x => x.RequestId)
                .Include(x => x.Employee)
                .ToList();
        }

        public Assignment GetByRequestId(int requestId)
        {
            return db.Assignments
                .Include(x => x.Employee)
                .Include(x => x.RequestId)
                .FirstOrDefault(x => x.RequestId == requestId);
        }

        public bool Delete(int id)
        {
            var data = db.Assignments.FirstOrDefault(r => r.Id == id);

            db.Assignments.Remove(data);
            return db.SaveChanges() > 0;
        }

    }
}
