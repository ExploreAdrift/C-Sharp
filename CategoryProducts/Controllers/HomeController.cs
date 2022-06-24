using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CategoryProducts.Models;

namespace CategoryProducts.Controllers;

public class HomeController : Controller
{
    private CatProdContext db;
    public HomeController(CatProdContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return RedirectToAction("Products", "Products");
        // Method and controller()
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
