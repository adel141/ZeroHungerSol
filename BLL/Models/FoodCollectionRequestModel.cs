using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class FoodCollectionRequestModel
    {

        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
     
        public DateTime RequestDate { get; set; }

        public DateTime PreservationDeadline { get; set; }
        [Required]
        public string Status { get; set; } = null!;
    }
}
