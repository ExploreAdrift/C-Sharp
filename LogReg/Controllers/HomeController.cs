using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace LogReg.Controllers;

public class HomeController : Controller
{
    private LogRegContext db;

    public HomeController(LogRegContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Reg()
    {
        return View("Register");
    }


    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        // Check initial ModelState
        if (ModelState.IsValid)
        {
            // If a User exists with provided email
            if (db.Users.Any(u => u.Email == newUser.Email))
            {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                ModelState.AddModelError("Email", "Email already in use!");

                return View("Register");
            }

            PasswordHasher<User> userVerify = new PasswordHasher<User>();
            newUser.Password = userVerify.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);

            return RedirectToAction("LoginPage");
        }
        return Reg();
    }
    [HttpGet("LoginPage")]
    public IActionResult LoginPage()
    {
        return View("LoginPage");
    }


    [HttpPost("Login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {

            var dbUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if (dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", "and Password don't match");
                return View("LoginPage");
            }
            var userVerify = new PasswordHasher<LoginUser>();
            var pwCompare = userVerify.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

            if (pwCompare == 0)
            {
                ModelState.AddModelError("LoginPassword", "This does not Match this Email");
                return View("LoginPage");
            }
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            return RedirectToAction("Success");
        }
        return View("Register");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Reg");
    }
    [HttpGet("Success")]
    public IActionResult Success()
    {
        var UserId = HttpContext.Session.GetInt32("UserId");
        if (UserId == null)
        {
            return Reg();
        }
        return View("Success");
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
