using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string title { get; set; }
        public virtual List<Category> categories { get; set; }

        public Question()
        {
            categories = new List<Category>();
        }
    }
}