using juno.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace juno.Controllers
{
    // Admin Controller
    public class AdminController : Controller
    {
        // GET: Admin/AdminPage
        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult EventAdd()
        {
            return View(); // This will return the EventAdd view
        }

        private readonly ApplicationDbContext _context = new ApplicationDbContext();  // Make sure to reference your DbContext here

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEvent(string clubName, string eventName, string location, int maxCapacity,
     DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime, string description,
     HttpPostedFileBase eventPhoto)
        {
            if (ModelState.IsValid)
            {
                // Extract the time part of the DateTime values
                TimeSpan timeFrom = startTime.TimeOfDay;
                TimeSpan timeTo = endTime.TimeOfDay;

                // Convert photo to byte array
                byte[] photoData = null;
                if (eventPhoto != null && eventPhoto.ContentLength > 0)
                {
                    using (var binaryReader = new BinaryReader(eventPhoto.InputStream))
                    {
                        photoData = binaryReader.ReadBytes(eventPhoto.ContentLength);
                    }
                }

                // Create a new Event object
                var newEvent = new Events
                {
                    Clubname = clubName,
                    Eventname = eventName,
                    Location = location,
                    MaximumCapacity = maxCapacity,
                    EventDate = startDate, // Using startDate for event date
                    TimeFrom = timeFrom,  // Assigning TimeSpan values
                    TimeTo = timeTo,  // Assigning TimeSpan values
                    Description = description,
                    Photo = photoData  // Store photo as byte array
                };

                // Add the event to the database
                _context.Events.Add(newEvent);
                _context.SaveChanges();

                // Redirect to a different page after successful submission
                return RedirectToAction("Events", "Admin");  // You can adjust this to your needs
            }

            // If the form is invalid, return to the same view to show validation errors
            return View();
        }


    }

}
