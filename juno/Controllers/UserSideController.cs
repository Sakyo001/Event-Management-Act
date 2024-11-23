using juno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace juno.Controllers
{
    public class UserSideController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult UserPage()
        {
            var events = _context.Events
                        .Where(e => e.EventDate >= DateTime.Now)
                        .ToList(); // Only show upcoming events
            return View(events);
        }

        public ActionResult PastEvents()
        {
            var pastEvents = _context.Events
                            .Where(e => e.EventDate < DateTime.Now)
                            .ToList(); // Show events that have passed
            return View(pastEvents);
        }

        public ActionResult RegisteredEvents()
        {
            return View();
        }



     


    }

}