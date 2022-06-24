using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CatProd.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CatProd.Controllers;

public class HomeController : Controller
{
    private CatProdContext db;
    public HomeController(CatProdContext context)
    {
        db = context;
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