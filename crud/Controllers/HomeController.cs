using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using crud.Models;

namespace crud.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    private DishContext db;

    public HomeController(DishContext context)
    {
        db = context;
    }




    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = db.Dishes.ToList();
        return View("Index", AllDishes);
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



    [HttpPost("view/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        return View("EditDish");
    }




    [HttpPost("/delete")]
    public IActionResult Delete(int dishId)
    {
        Dish dish = db.Dishes.FirstOrDefault(f => f.DishId == dishId);

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
