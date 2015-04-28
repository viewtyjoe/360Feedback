
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Description
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DescriptionId { get; set; }
        public int Position { get; set; }
        public string Value { get; set; }
        public Category Category { get; set; }
    }
}