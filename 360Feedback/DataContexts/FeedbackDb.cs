using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using _360Feedback.Models;

namespace _360Feedback.DataContexts
{
    public class FeedbackDb : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Response> Response { get; set; }

        public FeedbackDb() : base("name=DefaultConnection")
        {
            Console.WriteLine(Database.Connection.ConnectionString);
        }
    }
}