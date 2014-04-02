using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.ViewModels
{
    public class CategoriesPostsCommentsVM
    {
        public List<Category> Categories { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }

    }
}