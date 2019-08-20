using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chefs_N_Dishes.Models
{
    public class Chef
    {   
        [Key]
        public int ChefId { get; set; }


        [Required]
        [MinLength(2)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }


        [Required]
        [MinLength(2)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Birthday")]
        [Required]
        public DateTime Birthday { get; set; }

        public List<Dish> CookedDishes {get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    
}