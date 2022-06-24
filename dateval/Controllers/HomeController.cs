using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValid.Models;

namespace dateval.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }
    [HttpPost("process")]

    public IActionResult Process()
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("success");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpGet("success")]

    public IActionResult Success()
    {
        return View();
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
