using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class FoodCollectionRequestByRestaurantModel : FoodCollectionRequestModel
    {
        public string RestaurantName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int PhoneNumber { get; set; }



    }
}
