using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.ViewModels
{
    public class PostDateGroupVM
    {
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }
        public int PostCount { get; set; }
    }
}