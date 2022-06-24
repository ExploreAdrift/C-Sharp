using Microsoft.AspNetCore.Mvc;
namespace dojosurvey.Controllers;     //be sure to use your own project's namespace!
public class IndexController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet]       //type of request
    [Route("")]     //associated route string (exclude the leading /)
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]       //type of request
    [Route("Results")]     //associated route string (exclude the leading /)
    public IActionResult Results(string name, string location, string language, string comment)
    {
        ViewBag.name = name;
        ViewBag.location = location;
        ViewBag.language = language;
        ViewBag.comment = comment;

        return View();
    }
}