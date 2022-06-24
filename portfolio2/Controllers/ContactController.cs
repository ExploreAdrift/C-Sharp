using Microsoft.AspNetCore.Mvc;
namespace portfolio2.Controllers;     //be sure to use your own project's namespace!
public class ContactsController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet]       //type of request
    [Route("contacts")]     //associated route string (exclude the leading /)
    public IActionResult Contacts()
    {
        return View("Contacts");
    }
}