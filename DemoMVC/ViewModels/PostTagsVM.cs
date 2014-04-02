using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.ViewModels
{
    public class PostTagsVM
    {
        public int TagID { get; set; }
        public string Text { get; set; }
        public bool IsTagged { get; set; }
    }
}