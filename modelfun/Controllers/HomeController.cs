using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using modelfun.Models;

namespace modelfun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string message = "Obi - Wan Kenobi was a legendary Force - sensitive human male Jedi Master who served on the Jedi High Council during the final years of the Republic Era.As a Jedi General, Kenobi served in the Grand Army of the Republic that fought against the Separatist Droid Army during the Clone Wars.Kenobi, however, was forced into exile as a result of the Great Jedi Purge. As a mentor, Kenobi was responsible for training two members of the Skywalker family, Anakin Skywalker and Luke Skywalker, both of whom served in turn as his Padawan in the ways of the Force.";
        return View("index", message);
        // the string we made up above goes into return statement
    }
    [HttpGet("Numbers")]
    public IActionResult Numbers()
    {
        int[] numbersList = new int[]
        {
            5,11,23,27,30,0,00
        };
        return View(numbersList);
    }
    [HttpGet("users")]
    public IActionResult Users()
    {
        List<User> users = new List<User>();
        users.Add(new User("Moose", "Phillips"));
        users.Add(new User("Sarah"));
        users.Add(new User("Jerry"));
        users.Add(new User("Rene", "Ricky"));
        users.Add(new User("Barbara"));
        users.Add(new User("Doug"));
        users.Add(new User("Bob"));

        return View(users);
    }
    [HttpGet("user")]
    public IActionResult OneUser()
    {
        User Moose = new User("Moose", "Phillips");
        return View(Moose);
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
