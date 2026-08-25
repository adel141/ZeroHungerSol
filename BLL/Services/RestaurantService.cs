using AutoMapper;
using BLL.Models;
using DAL.EF.Table;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RestaurantService
    {


        private readonly IMapper mapper;
        private readonly RestaurantRepo repo;
        public RestaurantService(IMapper _mapper, RestaurantRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }

        public List<RestaurantModel> GetAll()
        {
            var data = repo.GetAll();
            return mapper.Map<List<RestaurantModel>>(data);
        }

        public RestaurantModel GetById(int id)
        {
            var data = repo.GetById(id);
            return mapper.Map<RestaurantModel>(data);
        }

        public bool Add(RestaurantModel model)
        {
            var data = mapper.Map<Restaurant>(model);
            repo.Add(data);
            return true;
        }

        public bool Update(int id, RestaurantModel model)
        {
            var data = repo.GetById(id);
            data = mapper.Map<Restaurant>(model);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
        
        public List<FoodCollectionRequestByRestaurantModel> GetCollectionRequestsByRestaurantId(int restaurantId)
        {
            var data = repo.GetFoodCollectionRequestsByRestaurantId(restaurantId);
            return mapper.Map<List<FoodCollectionRequestByRestaurantModel>>(data);
        }
    }
}
