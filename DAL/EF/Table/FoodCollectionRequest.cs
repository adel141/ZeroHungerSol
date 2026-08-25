using System;
using System.Collections.Generic;

namespace DAL.EF.Table;

public partial class FoodCollectionRequest
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime PreservationDeadline { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

    public virtual Restaurant Restaurant { get; set; } = null!;
}
