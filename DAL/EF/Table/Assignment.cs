using System;
using System.Collections.Generic;

namespace DAL.EF.Table;

public partial class Assignment
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime AcceptedAt { get; set; }

    public DateTime CollectedAt { get; set; }

    public DateTime DistributedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual FoodCollectionRequest Request { get; set; } = null!;
}
