using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Category
    {
        public string name { get; set; }
        public List<string> values { get; set; }
    }
}