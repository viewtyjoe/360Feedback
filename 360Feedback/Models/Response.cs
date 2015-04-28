using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _360Feedback.Models
{
    public class Response
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; }
        public Team Team { get; set; }
        public Student StudentFor { get; set; }
        public Student StudentFrom { get; set; }
        public string ResponseValues { get; set; }
    }
}