using
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using crudelicous.Models;


namespace crudelicous.Controllers;

public class HomeController : Controller
{
    private DishContext db;

    public HomeController(DishContext context)
    {
        db = context;
    }




    [HttpGet("")]
    public IActionResult Index()
    {

        return View("Index");
    }



    [HttpGet("/add/dish")]
    public IActionResult AddDish()
    {
        return View("NewDish");
    }



    [HttpPost("/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewDish");
        }
    }
    // edit dish
    // delete dish
    [HttpGet("read/{dishId}")]
    public IActionResult Read(int dishId)
    {
        Dish dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
    }

    [HttpPost("view/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        return View("EditDish");
    }

    [HttpPost("dish/{dishId}/update")]
    public IActionResult Update(int dishId, Dish editedDish)
    {
        if (ModelState.IsValid == false)
        {
            editedDish.DishId = dishId;
            return View("EditDish", editedDish);
        }
        Dish dbDish = db.Dishes.FirstOrDefault(u => u.DishId == dishId);

        if (dbDish == null)
        {
            RedirectToAction("Index");
        }

        db.Dish.Name = editedDish.Name;
        db.Dish.Chef = editedDish.Chef;
        db.Dish.Calories = editedDish.Calories;
        db.Dish.Description = editedDish.Description;
        db.Dish.Tastiness = editedDish.Tastiness;
        db.Dish.UpdatedAt = editedDish.UpdatedAt;

        db.Dishes.Update(dbDish);
        db.SaveChanges();
        return RedirectToAction();
    }




    [HttpPost("/delete")]
    public IActionResult Delete(int dishId)
    {
        Dish dish = db.Dish.FirstOrDefault(f => f.DishId == dishId);

        if (dish == null)
        {
            return RedirectToAction("Index");
        }

        db.Dishes.Remove(dish);
        db.SaveChanges();
        return RedirectToAction("Index");
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
