using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers;

public class MeetsController : Controller
{
    private BeltContext db;

    public MeetsController(BeltContext context)
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



    private bool loggedIn
    {
        get
        {
            return userid != null;
        }
    }

    [HttpGet("meetup/new")]
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
    [HttpPost("meetup/create")]
    public IActionResult Create(MeetUp newMeetup)
    {
        if (userid == null)
        {
            return RedirectToAction("Register", "Users");
        }

        // Building validation for wedding that cant be booked in the past and give error

        if (newMeetup.Date < DateTime.Now)
        {
            ModelState.AddModelError("Date", "Your Event cannot be in the past!");
        }

        // If its not a valid wedding, sending it back to "New"
        // Need line 71 below like 63 because if that validation fails it will redirect to "New"

        newMeetup.UserId = (int)userid;

        if (ModelState.IsValid == false)
        {
            return View("new");
        }

        // Converting to integer for session because it is nullable
        // This is assigning the weddings user id to the person logged in through session



        // adding and saving
        db.MeetUps.Add(newMeetup);
        db.SaveChanges();

        return RedirectToAction("meetup");
    }

    [HttpGet("/meetup")]
    public IActionResult Meetup()
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginReg", "Users");
        }

        List<MeetUp> meeting = db.MeetUps.Include(w => w.Participants).Include(w => w.Creator).Where(w => w.Date > DateTime.Now).ToList();

        return View("Meetup", meeting);
    }


    [HttpGet("meetup/{MeetId}")]
    public IActionResult OneMeet(int MeetId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginReg", "Users");
        }


        MeetUp? meetup = db.MeetUps.Include(w => w.Creator).Include(r => r.Participants).ThenInclude(r => r.User).FirstOrDefault(w => w.MeetUpId == MeetId);

        if (meetup == null)
        {
            return RedirectToAction("meetup");
        }


        return View("OneMeet", meetup);
    }

    [HttpGet("/delete/{MeetUpId}")]
    public IActionResult Deleted(int MeetUpId)
    {

        MeetUp? delete = db.MeetUps.FirstOrDefault(m => m.MeetUpId == MeetUpId);
        db.MeetUps.Remove(delete);
        db.SaveChanges();

        return RedirectToAction("MeetUp");


    }
    [HttpPost("/meetup/{MeetId}/participant")]
    public IActionResult Part(int MeetId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginReg", "Users");
        }

        Participant? existingPart = db.Participants.FirstOrDefault(r => r.UserId == userid && r.MeetUpId == MeetId);
        // The first rsvp have the where the rsvp has the ID of the person who is logged in the WeddingId is equal to our passed in value.

        if (existingPart == null)
        {
            // IF there is no RSVP this will assign it. It is assigning the UserId to the currently logged in session ID.
            Participant newPart = new Participant()
            {
                MeetUpId = MeetId,
                UserId = (int)userid
            };

            db.Participants.Add(newPart);
        }

        // If there is RSVP already, we can remove it.

        else
        {
            db.Participants.Remove(existingPart);
        }
        db.SaveChanges();
        return RedirectToAction("Meetup");
    }





}