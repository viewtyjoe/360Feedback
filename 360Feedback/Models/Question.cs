using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string title { get; set; }
        public List<Category> categories { get; set; }
    }
}