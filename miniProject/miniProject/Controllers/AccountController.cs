using miniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miniProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly MiniSchoolContext _db = new MiniSchoolContext();

       
        public ActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Login(User userModel)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users
                    .FirstOrDefault(u => u.Email == userModel.Email && u.Password == userModel.Password);

                if (user != null)
                {
                    
                    Session["UserId"] = user.Id;
                    Session["UserEmail"] = user.Email;

                
                    return RedirectToAction("Index", "MiniProject");
                }

                ModelState.AddModelError("", "Invalid email or password.");
            }

            return View(userModel);
        }

        
        public ActionResult Logout()
        {
           
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Account");
        }
    }
}