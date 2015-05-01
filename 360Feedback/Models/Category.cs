using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string name { get; set; }
        public Question Question { get; set; }
        public virtual List<Description> Descriptions { get; set; }

        public Category()
        {
            Descriptions = new List<Description>();
        }
    }
}