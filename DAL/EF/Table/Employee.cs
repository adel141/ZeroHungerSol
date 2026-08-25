using System;
using System.Collections.Generic;

namespace DAL.EF.Table;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}
