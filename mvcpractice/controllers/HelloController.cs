using Microsoft.AspNetCore.Mvc;
namespace mvcpractice.Controllers;     //be sure to use your own project's namespace!
public class HelloController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet("")]       //type of request// LOCALHOST:5000

    public ViewResult index()
    {
        // looking for Index.cshtml inside HelloController
        return View();
    }

    // LOCALHOST:5000/HELLO
    [HttpGet("hello")]

    public RedirectToActionResult hello()
    {
        // localhost:5000
        Console.WriteLine("Waddup you're redirecting");
        return RedirectToAction("index");
    }


    public string Hello()
    {
        return "Hi Again!";
    }
    // LOCALHOST:5000/USERS/???
    [HttpGet("users/{username}/{location}")]
    public string HelloUser(string username, string location)
    {
        if (location == "iceland")
            return $"Hello {username} from {location} , damn it's cold";
        return $"Hello {username} from {location}";
    }
}
