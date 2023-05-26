using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HManAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult How_To_Play()
        {
            ViewBag.Message = "How To play page.";
            return View();
        }
        [Authorize]
        public ActionResult HMan()
        {
            List<string> list = new List<string>()
            {
                 "Name1",
                 "Name2"
            };
            ViewBag.Message = "HangMan";
            return View(list);
        }

     }
}