using AutoMapper;
using BLL.Models;
using DAL.EF.Table;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class FoodCollectionRequestService
    {

        private readonly IMapper mapper;
        private readonly FoodCollectionRequestRepo repo;
        public FoodCollectionRequestService(IMapper _mapper, FoodCollectionRequestRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }

        public List<FoodCollectionRequestModel> GetAll()
        {
            var data = repo.GetAll();
            return mapper.Map<List<FoodCollectionRequestModel>>(data);
        }

        public FoodCollectionRequestModel GetById(int id)
        {
            var data = repo.GetById(id);
            return mapper.Map<FoodCollectionRequestModel>(data);
        }

        public bool Add(FoodCollectionRequestModel model)
        {
            var data = mapper.Map<FoodCollectionRequest>(model);
            repo.Add(data);
            return true;
        }

        public bool Update(int id,FoodCollectionRequestModel model)
        {
            var data = mapper.Map<FoodCollectionRequest>(model);
            return repo.Update(data);
        }

 
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public bool UpdateStatus(int id, string status)
        {
            var data = repo.GetById(id);
            if (data == null)
            {
                return false;
            }
            data.Status = status;
            return repo.Update(data);
        }
    }
}
