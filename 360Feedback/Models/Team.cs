using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Team
    {
        public string teamName { get; set; }
        public List<Student> students { get; set; }
    }
}