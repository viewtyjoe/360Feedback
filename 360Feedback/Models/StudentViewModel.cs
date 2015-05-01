using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class StudentViewModel
    {
        public Student Student{ get; set; }
        public List<Student> TeamMembers { get; set; }
        public List<Question> Questions { get; set; }
    }
}