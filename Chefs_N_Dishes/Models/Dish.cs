using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Chefs_N_Dishes.Models
{
    public class Dish
    { 
        [Key]
        public int DishId { get; set; }
        [Required]
        [Display(Name=("Name of Dish"))]
        public string Dish_Name{ get; set; }
        
        [Required]
        [Range(1,5)]
        public int Tastiness{ get; set; }
        
        [Required]
        [Range(1,int.MaxValue)]
        public int Calories{ get; set; }
        
        [Required]
        public string Description{ get; set; } 
        //Foreign Key
        [Display(Name=("Chef"))]
        public int ChefId { get; set; }

        //Navigation property
        public Chef Creator { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}