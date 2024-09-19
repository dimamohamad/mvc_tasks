using miniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miniProject.Controllers
{
    public class MiniProjectController : Controller
    {
        private readonly MiniSchoolContext _db = new MiniSchoolContext();

        
        public ActionResult Index()
        {
            var classes = _db.Classes.ToList();

            
            ViewBag.Classes = classes;

            return View();
        }
    }
}