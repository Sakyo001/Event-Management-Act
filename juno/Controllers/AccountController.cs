using juno.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace juno.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // L O G   I N 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Find the user based on the provided username and password
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null && user.Role == "User")
            {
                // Store user info in session for later use
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;

                // Redirect to the UserPage in the UserSide controller
                return RedirectToAction("UserPage", "UserSide");
            }
            else if (user != null)
            {
                // If the user is not a User, show a message
                ViewBag.Message = "Bruh this account doesn't even exist, sign up!";
                return View();
            }

            // If no matching user or incorrect credentials
            ViewBag.Message = "Invalid username or password.";
            return View();
        }





        // S I G N   U P   F O R   U S E R
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            if (ModelState.IsValid)
            {
                model.Role = "User"; //Default Role for user signup
                _context.Users.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(model);
        }





        // A D M I N   L O G I N 
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null && user.Role == "Admin")
            {
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;

                return RedirectToAction("AdminPage", "Admin");
            }
            else if (user != null)
            {
                ViewBag.Message = "You are not authorized to access the admin page.";
                return View();
            }

            ViewBag.Message = "Invalid username or password.";
            return View();
        }

        // Logout action to clear session and log out the user
        public ActionResult Logout()
        {
            // Clear the session to log out the user
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
