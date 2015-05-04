using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using _360Feedback.Models;
using _360Feedback.DataContexts;


namespace _360Feedback.Controllers
{
    public class StudentController : Controller
    {
        private FeedbackDb Db = new FeedbackDb();

        public ActionResult StudentView()
        {
            String studentUrl = Request.Params["Id"];
            Byte[] decoded = HttpServerUtility.UrlTokenDecode(studentUrl);
            String user = GetString(decoded);

            List<Team> allTeams = Db.Teams.ToList();
            StudentViewModel svm = new StudentViewModel();
            svm.Questions = Db.Questions.ToList<Question>();
            svm.Student = Db.Students.First<Student>(s => s.Email == user);
            Team team = allTeams.Where(x => x.Students.Contains(svm.Student)).SingleOrDefault();
            svm.Student.Team = team;

            List<Student> teamMembers = svm.Student.Team.Students.ToList();
            teamMembers.RemoveAll(x => x.Email == svm.Student.Email);
            svm.TeamMembers = teamMembers;
            //foreach(var document in db)

            return View(svm);
        }


        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}