using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Team
    {
        [Required]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}