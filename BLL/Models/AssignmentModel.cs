using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class AssignmentModel
    {

        public int Id { get; set; }

        public int RequestId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime AcceptedAt { get; set; }

        public DateTime CollectedAt { get; set; }

        public DateTime DistributedAt { get; set; }
    }
}
