using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using password.Models;
using Microsoft.AspNetCore.Http;



namespace password.Controllers;

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
        // GOING TO SITE WILL GIVE NULL VALUE, SETTING TO ONE SO WE CAN INCREASE COUNTER
        if (HttpContext.Session.GetInt32("NewPassword") == null)
        {
            HttpContext.Session.SetInt32("NewPassword", 1);
        }
        else
        {
            // TO RETRIEVE AN INT FROM SESSION WE USE ".GetInt32"
            int? count = HttpContext.Session.GetInt32("NewPassword");


            // WE ADD ONE PER CLICK
            count += 1;
            // TO STORE AN INT IN SESSION WE USE ".SetInt32"
            HttpContext.Session.SetInt32("NewPassword", Convert.ToInt32(count));

        }
        Random rand = new Random();
        // USE THESE TO PULL FROM
        string letNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        // FILL IN PASSWORD
        string NewPassword = "";
        // MUST BE 14 LETTERS
        for (int i = 0; i < 14; i++)
        {
            NewPassword += letNum[rand.Next(letNum.Length)];
            // NewPassWord IS BEING ACTUALLY RANDOMIZED HERE AND SENT/INCLUSIVE AND EXCLUSIVE
        }
        return View("Index", NewPassword);
    }

    [HttpPost("NewPass")]

    public IActionResult NewPass()
    {
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
