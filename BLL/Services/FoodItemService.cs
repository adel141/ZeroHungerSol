using AutoMapper;
using BLL.Models;
using DAL.EF.Table;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class FoodItemService
    {


        private readonly IMapper mapper;
        private readonly FoodItemRepo repo;
        public FoodItemService(IMapper _mapper, FoodItemRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }

        public List<FoodItemModel> GetAll()
        {
            var data = repo.GetAll();
            return mapper.Map<List<FoodItemModel>>(data);
        }

        public FoodItemModel GetById(int id)
        {
            var data = repo.GetById(id);
            return mapper.Map<FoodItemModel>(data);
        }

        public bool Add(FoodItemModel model)
        {
            var data = mapper.Map<FoodItem>(model);
            repo.Add(data);
            return true;
        }

        public bool Update(int id, FoodItemModel model)
        {
            var data = repo.GetById(id);
            data = mapper.Map<FoodItem>(model);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}
