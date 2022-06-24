using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojosurveytwo.Models;

namespace dojosurveytwo.Controllers;

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

    [HttpPost("Results")]       //type of request //associated route string (exclude the leading /)
    // TIED TO INDEX

    public IActionResult Result(ResultsSurvey survey)
    {
        if (ModelState.IsValid)
        {
            return View(survey);
            // HttpContext.Session.SetString("Submit", survey.Submit);
            // return RedirectToAction("StoryTime");
        }
        else
        {
            return Index();
        }

    }
    // [HttpGet("/story")]
    // public IActionResult StoryTime()
    // {
    //     string story = HttpContent.Session.GetString("story");
    //     if (story == null)
    //     {
    //         HttpContext.Session.GetString("story","")
    //     }
    // }

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
