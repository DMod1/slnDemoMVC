using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMVC.HtmlHelpers;

namespace DemoMVC.Controllers
{
    public class LoadTuxController : Controller
    {
        //
        // GET: /LoadTux/
        public ActionResult Index()
        {
            NameValueCollection nvc = Request.Form;

            var chemin = Server.MapPath("/Images");

            var mesFichier = Directory.GetFiles(chemin);

            List<string> res = mesFichier.Select(x => x.Split('\\')[x.Split('\\').Count() - 1].Split('.')[0]).ToList();

            string pathImg = "";
            string selected = "";
            if (!string.IsNullOrEmpty(nvc["cboTux"]))
            {
                selected = nvc["cboTux"];                
                pathImg = "/Images/"+ selected + ".png";
            }

            ViewBag.PathImg = pathImg;
            ViewBag.Selected = selected;
            ViewBag.Data = res;
            return View();
        }

        public ActionResult Helper()
        {
            NameValueCollection nvc = Request.Form;

            var chemin = Server.MapPath("/Images");
            string ImageChoisie = "";
            string selected = "";
            
            if (!string.IsNullOrEmpty(nvc["lstItem"]))
            {
                selected = nvc["lstItem"];
                ImageChoisie = "/Images/" + selected + ".png";
            }

            var mesFichier = Directory.GetFiles(chemin);

            List<SelectListItem> res = mesFichier.Select(x => x.Split('\\')[x.Split('\\').Count() - 1].Split('.')[0]).Select(x=> new SelectListItem {Text = x, Selected = x == selected ? true : false }).ToList();



            ViewBag.PathImg = ImageChoisie;
            ViewBag.Selected = selected;
            ViewBag.lstItem = res;
            return View();
        }
    }
}