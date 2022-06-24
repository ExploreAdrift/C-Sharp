using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace ChefsDishes.Controllers;

public class HomeController : Controller
{
    private CDContext db;

    public HomeController(CDContext context)
    {
        db = context;
    }



    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = db.Chefs
        // populates each Message with its related User object (Creator)
        .Include(chef => chef.MadeDish)
        .ToList();
        ViewBag.allchefs = AllChefs;
        return View("Index");
    }


    [HttpGet("Dishes")]
    public IActionResult Dish()
    {
        List<Dish> AllDishes = db.Dishes
        // populates each Message with its related User object (Creator)
        .Include(dish => dish.Creator)
        .ToList();
        ViewBag.alldishes = AllDishes;
        return View("Dishes");
    }


    [HttpGet("AddChefHtml")]
    public IActionResult AddChefHtml()
    {
        return View("AddChef");
    }


    [HttpPost("AddChef")]
    public IActionResult AddChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {


            db.Add(newChef);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChef");
        }
    }
    [HttpGet("AddDishHtml")]
    public IActionResult AddDishHtml()
    {
        List<Chef> AllChefs = db.Chefs.ToList();
        ViewBag.allchefs = AllChefs;
        return View("AddDish");
    }


    [HttpPost("AddDish")]
    public IActionResult AddDish(Dish dish)

    {
        if (ModelState.IsValid)
        {
            db.Add(dish);
            db.SaveChanges();
            return RedirectToAction("AddDishHtml");
        }
        else
        {
            List<Chef> AllChefs = db.Chefs.ToList();
            ViewBag.allchefs = AllChefs;
            return View("AddDish", dish);
        }
    }







    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
