using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Student
    {
        [Required, Key]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Completed { get; set; }
        [Required]
        public Team Team { get; set; }
    }
}