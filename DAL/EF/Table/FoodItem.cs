using System;
using System.Collections.Generic;

namespace DAL.EF.Table;

public partial class FoodItem
{
    public int Id { get; set; }

    public string FoodName { get; set; } = null!;

    public double Quantity { get; set; }

    public string Unit { get; set; } = null!;

    public int RequestId { get; set; }

    public virtual FoodCollectionRequest Request { get; set; } = null!;
}
