using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public Team Team { get; set; }
        public Student StudentFor { get; set; }
        public Student StudentFrom { get; set; }
        public string ResponseValues { get; set; }
    }
}