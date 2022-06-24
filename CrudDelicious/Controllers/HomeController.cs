using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudDelicious.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrudDelicious.Controllers;

public class HomeController : Controller
{

    private DishContext db;

    public HomeController(DishContext context)
    {
        db = context;
    }
    [HttpGet("/")]
    public IActionResult Index()
    {
        return RedirectToAction("All", "Dishes");
    }


    [HttpGet("dishes/new")]
    public IActionResult New()
    {
        return View("NewDish");
    }

    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid == false)
        {
            return New();
        }

        db.Dishes.Add(newDish);
        db.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpGet("/dishes/all")]
    public IActionResult All()
    {
        List<Dish> allDishes = db.Dishes.ToList();

        return View("All", allDishes);
    }

    [HttpGet("/dishes/{dishID}")]
    public IActionResult Details(int dishID)
    {
        Dish? dish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishID);

        if (dish == null)
        {
            return RedirectToAction("All");
        }
        return View(dish);
    }

    [HttpPost("/dishes/delete/{dishId}")]
    public IActionResult Delete(int dishId)
    {
        Dish? dish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        if (dish != null)
        {
            db.Dishes.Remove(dish);
            db.SaveChanges();
        }
        return RedirectToAction("All");
    }

    [HttpGet("/dishes/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Dish? dish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        if (dish != null)
        {
            return View("Edit", dish);
        }
        return RedirectToAction("All");
    }

    [HttpPost("/dishes/{dishId}/update")]
    public IActionResult Update(Dish editedDish, int dishId)
    {
        if (ModelState.IsValid)
        {
            Dish? dbDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            if (dbDish != null)
            {
                dbDish.Name = editedDish.Name;
                dbDish.Chef = editedDish.Chef;
                dbDish.Tastiness = editedDish.Tastiness;
                dbDish.Calories = editedDish.Calories;
                dbDish.Description = editedDish.Description;
                dbDish.UpdatedAt = DateTime.Now;

                db.Dishes.Update(dbDish);
                db.SaveChanges();
            }
            return RedirectToAction("Details", dishId);

        }
        else
        {
            return Edit(dishId);
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
