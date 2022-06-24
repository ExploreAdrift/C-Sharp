using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using practicetwo.Models;
using Microsoft.AspNetCore.Http;

namespace practicetwo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [HttpGet("")]       //type of request
                        //associated route string (exclude the leading /)
    public IActionResult Index()

    {
        return View("Index");
    }

    [HttpPost("submit")]       //type of request //associated route string (exclude the leading /)

    public IActionResult Submit(ResultsSubmit results)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Result");
        }
        else
        {
            return Index();
        }

    }

    [HttpGet]
    [Route("result")]
    public IActionResult Result(ResultsSubmit results)
    {
        return View(results);
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
