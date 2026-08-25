using System;
using System.Collections.Generic;

namespace DAL.EF.Table;

public partial class Restaurant
{
    public int Id { get; set; }

    public string RestaurantName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public virtual ICollection<FoodCollectionRequest> FoodCollectionRequests { get; set; } = new List<FoodCollectionRequest>();
}
