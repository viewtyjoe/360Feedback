
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Description
    {
        public int DescriptionId { get; set; }
        public int Position { get; set; }
        public string Value { get; set; }
        public Category Category { get; set; }
    }
}