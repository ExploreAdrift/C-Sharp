using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class WeddingsController : Controller
{
    private WeddingContext db;

    public WeddingsController(WeddingContext context)
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
    // shorthand if the user is logged in through session


    [HttpGet("wedding/new")]
    public IActionResult New()
    {

        if (!loggedIn)
        {
            return RedirectToAction("Register", "Users");
        }
        // Checking to see if user is logged in and directing them to "Register" in the "Users" Controller

        return View("New");
        // otherwise we are sending them to the "new" view
    }



    [HttpPost("wedding/create")]
    public IActionResult Create(Wedding newWedding)
    {
        if (userid == null)
        {
            return RedirectToAction("Register", "Users");
        }

        // Building validation for wedding that cant be booked in the past and give error

        if (newWedding.Date < DateTime.Now)
        {
            ModelState.AddModelError("Date", "Your wedding cannot be in the past!");
        }

        // If its not a valid wedding, sending it back to "New"
        // Need line 71 below like 63 because if that validation fails it will redirect to "New"

        if (ModelState.IsValid == false)
        {
            return View("new");
        }

        // Converting to integer for session because it is nullable
        // This is assigning the weddings user id to the person logged in through session

        newWedding.UserId = (int)userid;

        // adding and saving
        db.Weddings.Add(newWedding);
        db.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginReg", "Users");
        }

        // include the creator of the wedding (Up to where we are including Rsvps that is one to many.)

        List<Wedding> weddings = db.Weddings.Include(w => w.Creator).Include(r => r.Rsvps).Where(w => w.Date > DateTime.Now).ToList();

        // Sending the list data from 95 into the dashboard page(line 99), passing weddings into it. 
        // Line 98 is so it only shows the weddings from this date on. We are just including RSVP on it.

        return View("Dashboard", weddings);
    }

    [HttpGet("weddings/{WeddingId}")]
    public IActionResult OneWedding(int WeddingId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginReg", "Users");
        }

        // Line 116 is asking if there are any weddings with that wedding ID, then we want to include the people who have RSVPed

        Wedding? wedding = db.Weddings.Include(w => w.Creator).Include(r => r.Rsvps).ThenInclude(r => r.user).FirstOrDefault(w => w.WeddingId == WeddingId);

        if (wedding == null)
        {
            return RedirectToAction("Dashboard");
        }

        // Passing in wedding from line 166 into the view of OneWedding

        return View("OneWedding", wedding);
    }

    [HttpPost("/weddings/{WeddingId}/rsvp")]
    public IActionResult RSVP(int WeddingId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginReg", "Users");
        }

        Rsvp? existingRsvp = db.Rsvps.FirstOrDefault(r => r.UserId == userid && r.WeddingId == WeddingId);
        // The first rsvp have the where the rsvp has the ID of the person who is logged in the WeddingId is equal to our passed in value.

        if (existingRsvp == null)
        {
            // IF there is no RSVP this will assign it. It is assigning the UserId to the currently logged in session ID.
            Rsvp newRsvp = new Rsvp()
            {
                WeddingId = WeddingId,
                UserId = (int)userid
            };

            db.Rsvps.Add(newRsvp);
        }

        // If there is RSVP already, we can remove it.

        else
        {
            db.Rsvps.Remove(existingRsvp);
        }
        db.SaveChanges();
        return RedirectToAction("Dashboard");
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
