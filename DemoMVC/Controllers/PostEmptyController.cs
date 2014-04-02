using DemoMVC.Models;
using DemoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class PostEmptyController : Controller
    {
        private Db2014BlogCodeFirstEntities1 context = new Db2014BlogCodeFirstEntities1();
        //
        // GET: /PostEmpty/
        public ActionResult Index()
        {
            return View(context.Posts.ToList());
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(context.Posts.Where(p => p.Category.Description.ToUpper().Contains(searchString.ToUpper())).ToList());
            }
            return View(context.Posts.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Today = DateTime.Now;
            ViewBag.CategoryID = new SelectList(context.Categories, "CategoryID", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post p)
        {
            context.Posts.Add(p);
            context.SaveChanges();

            ViewBag.CategoryID = new SelectList(context.Categories, "CategoryID", "Description");
            return View();
        }

        public ActionResult Edit(int id)
        {
            Post pEdit = context.Posts.Find(id);
            List<PostTagsVM> lstTags = context.Tags.ToList().Select(
                x => new PostTagsVM { 
                    TagID = x.TagId,
                    Text = x.Text,
                    IsTagged = pEdit.Tags1.Any(y => y.TagId == x.TagId) 
                }).ToList();

            ViewBag.TagID = lstTags;

            ViewBag.CategoryID = new SelectList(context.Categories, "CategoryID", "Description", pEdit.CategoryID);
            return View(pEdit);
        }

        [HttpPost]
        public ActionResult Edit(Post p, int[] tags)
        {
            Post pUpdate = context.Posts.Find(p.PostID);
            foreach (Tag t in context.Tags.ToList())
            {
                if (!pUpdate.Tags1.Any(x => x.TagId == t.TagId) && tags.Any(x => x == t.TagId))
                    pUpdate.Tags1.Add(t);
                if (pUpdate.Tags1.Any(x => x.TagId == t.TagId) && !tags.Any(x => x == t.TagId))
                    pUpdate.Tags1.Remove(t);
            }
            TryUpdateModel(pUpdate, new string[] { "NumberOfReading", "Resume"});
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Post p = context.Posts.Find(id);
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            Post p = context.Posts.Find(id);

            return View(p);
        }

        [HttpPost]
        public ActionResult DeletePost(int? id)
        {
            //string id = Request.Form["id"];
            Post p = context.Posts.Find(id);
            context.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GroupDatePost()
        {
            List<PostDateGroupVM> lstGroup = (from unP
                                in context.Posts
                                              group unP by unP.CreatedDate into groupDate
                                              select new PostDateGroupVM
                                              {
                                                  CreateDate = groupDate.Key,
                                                  PostCount = groupDate.Count()
                                              }
                            ).ToList();

            return View(lstGroup);
        }

        public ActionResult CategoriePost(int? idCategory, int? idPost)
        {
            CategoriesPostsCommentsVM VM = new CategoriesPostsCommentsVM();

            VM.Categories = context.Categories.ToList();
            VM.Posts = idCategory == null ? null : context.Posts.Where(p => p.CategoryID == idCategory).ToList().Count == 0 ? null : context.Posts.Where(p => p.CategoryID == idCategory).ToList();
            VM.Comments = idPost == null ? null : context.Comments.Where(c => c.PostID == idPost).ToList().Count == 0 ? null : context.Comments.Where(c => c.PostID == idPost).ToList();

            return View(VM);
        }

        public ActionResult CategoriePostVersionPartial(int? idCategory, int? idPost)
        {
            CategoriesPostsCommentsVM VM = new CategoriesPostsCommentsVM();

            VM.Categories = context.Categories.ToList();
            VM.Posts = idCategory == null ? null : context.Posts.Where(p => p.CategoryID == idCategory).ToList().Count == 0 ? null : context.Posts.Where(p => p.CategoryID == idCategory).ToList();
            VM.Comments = idPost == null ? null : context.Comments.Where(c => c.PostID == idPost).ToList().Count == 0 ? null : context.Comments.Where(c => c.PostID == idPost).ToList();

            return View(VM);
        }
    }
}