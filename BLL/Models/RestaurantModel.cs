using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string RestaurantName { get; set; } = null!;
        
        [MaxLength(100)]
        public string Address { get; set; } = null!;
        [Phone]
        public int PhoneNumber { get; set; }

    }
}
