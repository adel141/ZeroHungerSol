using AutoMapper;
using BLL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class EmployeeService
    {

        private readonly IMapper mapper;
        private readonly EmployeeRepo repo;
        public EmployeeService(IMapper _mapper, EmployeeRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }

        public List<EmployeeModel> GetAll()
        {
            var data = repo.GetAll();
            return mapper.Map<List<EmployeeModel>>(data);
        }

        public EmployeeModel GetById(int id)
        {
            var data = repo.GetById(id);
            return mapper.Map<EmployeeModel>(data);
        }

        public bool Add(EmployeeModel model)
        {
            var data = mapper.Map<DAL.EF.Table.Employee>(model);
            repo.Add(data);
            return true;
        }

        public bool Update(int id ,EmployeeModel model)
        {
            var data = repo.GetById(id);
            if (data == null)
            {
                return false;
            }
            data = mapper.Map<DAL.EF.Table.Employee>(model);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}
