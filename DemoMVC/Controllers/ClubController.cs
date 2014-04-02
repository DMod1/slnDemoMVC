using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class ClubController : Controller
    {
        //
        // GET: /Club/

        public ActionResult Index()
        {
            ViewBag.leagueOne = new List<string> { "PSG", "OM", "OL" };
            return View();
        }

        
    }
}