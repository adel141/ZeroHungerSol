using AutoMapper;
using BLL.Models;
using DAL.EF.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RestaurantModel, Restaurant>().ReverseMap();
            CreateMap<EmployeeModel, Employee>().ReverseMap();
            CreateMap<AssignmentModel, Assignment>().ReverseMap();
            CreateMap<FoodCollectionRequestModel, FoodCollectionRequest>().ReverseMap();
            CreateMap<FoodItemModel, FoodItem>().ReverseMap();
            CreateMap<FoodCollectionRequestByRestaurantModel, FoodCollectionRequest>().ReverseMap();

        }
    }
}
