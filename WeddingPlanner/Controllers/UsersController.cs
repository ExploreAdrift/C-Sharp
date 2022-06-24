using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class UsersController : Controller
{
    private WeddingContext db;

    public UsersController(WeddingContext context)
    {
        db = context;
    }

    private int? userid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }
    // Short hand for session


    private bool loggedIn
    {
        get
        {
            return userid != null;
        }
    }


    [HttpGet("/")]
    public IActionResult LoginReg()
    {
        // This will not let the currently logged in person see the login reg page

        if (userid != null)
        {
            return RedirectToAction("Dashboard", "Weddings");
        }

        return View("LoginReg");
    }


    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        // Check initial ModelState
        if (ModelState.IsValid == false)
        {
            return View("LoginReg");
        }
        {
            // If a User exists with provided email
            if (db.Users.Any(u => u.Email == newUser.Email))
            {

                ModelState.AddModelError("Email", "Email already in use!");

                return View("LoginReg");
            }

            PasswordHasher<User> userVerify = new PasswordHasher<User>();
            newUser.Password = userVerify.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);

            return RedirectToAction("Dashboard", "Weddings");
        }

    }


    [HttpPost("Login")]
    public IActionResult Login(UserLogin loginUser)
    {
        if (ModelState.IsValid)
        {

            var dbUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if (dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", "Email and Password do not match");
                return View("LoginReg");
            }
            var userVerify = new PasswordHasher<UserLogin>();
            var pwCompare = userVerify.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

            if (pwCompare == 0)
            {
                ModelState.AddModelError("LoginPassword", "This does not Match this Email");
                return View("LoginReg");
            }
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            return RedirectToAction("Dashboard", "Weddings");
        }
        return View("LoginReg");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LoginReg");
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
