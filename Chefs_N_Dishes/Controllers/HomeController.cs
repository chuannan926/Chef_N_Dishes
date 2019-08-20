using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chefs_N_Dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs_N_Dishes.Controllers
{
    
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext Context)
        {
            dbContext = Context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> All_Chefs = dbContext.Chefs
                .Include(chef => chef.CookedDishes) 
                .ToList();
            return View("Index", All_Chefs);
        }
        
        [HttpGet("new")]
        public IActionResult New()
        {
            return View ("new_chef");
        
        }

        [HttpPost("create")]
        public IActionResult Create(Chef My_chef)
        {   System.Console.WriteLine(My_chef.FirstName);
            System.Console.WriteLine(My_chef.LastName);
            System.Console.WriteLine(My_chef.Birthday);
            if (ModelState.IsValid)       
            {
                System.Console.WriteLine("VALID *********");
                dbContext.Chefs.Add(My_chef); // Add the dish to the DB
                dbContext.SaveChanges(); 
                return RedirectToAction("Index");
            }
            else
            {   
                return View("new_chef");
            }
        }
        
        
        
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> All_Dishes = dbContext.Dishes
                .Include(dish => dish.Creator)
                .ToList();
            return View ("dish", All_Dishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult Adding_dish()
        {   
            List<Chef> All_Chefs = dbContext.Chefs.ToList();
            ViewBag.All_Chefs = All_Chefs;
            return View ("Add_dish");
        }


        [HttpPost("newdish")]
        public IActionResult Add_dish(Dish My_dish)
        {
            System.Console.WriteLine(My_dish.Dish_Name);
            System.Console.WriteLine(My_dish.Calories);
            System.Console.WriteLine(My_dish.Tastiness);
            System.Console.WriteLine(My_dish.Description);
            System.Console.WriteLine(My_dish.ChefId);
            if (ModelState.IsValid)       
            {   
                System.Console.WriteLine("VALID *********");
                dbContext.Dishes.Add(My_dish); // Add the dish to the DB
                dbContext.SaveChanges(); 
                return RedirectToAction("dishes");
            }
            else
            {
                List<Chef> All_Chefs = dbContext.Chefs.ToList();
                ViewBag.All_Chefs = All_Chefs;
                return View("Add_dish");
            }
            
        }

    }
}
