using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string name { get; set; }
        public Question Question { get; set; }
        public List<Description> Descriptions { get; set; }
    }
}