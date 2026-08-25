using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class FoodItemModel
    {

        public int Id { get; set; }
        [Required]
        public string FoodName { get; set; } = null!;
        [Required]
        public double Quantity { get; set; }
        [Range(0,100)]
        public string Unit { get; set; } = null!;

        public int RequestId { get; set; }
    }
}
