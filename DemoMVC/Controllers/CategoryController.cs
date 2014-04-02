using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Index()
        {
            Models.Db2014BlogCodeFirstEntities1 context = new Models.Db2014BlogCodeFirstEntities1();

            var lstCatString = context.Categories.Select(x => new { Text = x.Description, Value = x.CategoryID }).ToList();

            List<SelectListItem> lesCategories = lstCatString.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() }).ToList();

            ViewBag.lstCategory = lesCategories;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category c)
        {
            Models.Db2014BlogCodeFirstEntities1 context = new Models.Db2014BlogCodeFirstEntities1();
            context.Categories.Add(c);
            context.SaveChanges();
            return View();
        }
    }
}