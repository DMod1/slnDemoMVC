using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/
        public ActionResult Index()
        {
            ViewBag.MaDate = DateTime.Today;
            return View();
        }
	}
}