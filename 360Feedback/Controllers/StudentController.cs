using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web.Script;
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

        [HttpPost]
        public async Task<ActionResult> SaveResponse()
        {
            try
            {
                var questionCount = Int32.Parse(Request.Params["questionCount"]);
                var studentCount = Int32.Parse(Request.Params["studentCount"]);
                int fromId = Int32.Parse(Request.Params["studentIdFrom"]);
                Student studentFrom = await Db.Students.FindAsync(fromId);
                List<Question> questions = Db.Questions.ToList<Question>();
                List<Category> categories = Db.Categories.ToList<Category>();
                for (int i = 0; i < studentCount; i++)
                {
                    string response = "";
                    Response saveResponse = new Response();
                    int forId = Int32.Parse(Request.Params["student" + i]);
                    if (Db.Response.Any<Response>(r => r.StudentFrom.StudentId == fromId && r.StudentFor.StudentId == forId))
                    {
                        Response oldResponse = Db.Response.First<Response>(r => r.StudentFrom.StudentId == fromId && r.StudentFor.StudentId == forId);
                        Db.Response.Remove(oldResponse);
                    }
                    saveResponse.StudentFrom = studentFrom;
                    saveResponse.StudentFor = await Db.Students.FindAsync(forId);
                    for (int j = 0; j < questionCount; j++)
                    {
                        response += Request.Params["student" + i + "question" + j];
                        if (j < questionCount - 1)
                        {
                            response += ",";
                        }
                    }
                    saveResponse.ResponseValues = response;
                    var teamId = Int32.Parse(Request.Params["teamId"]);
                    saveResponse.Team = await Db.Teams.FindAsync(teamId);
                    Db.Response.Add(saveResponse);
                }
                studentFrom.Completed = true;
                await Db.SaveChangesAsync();
                return View();
            }
            catch(Exception e)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Error()
        {
            return View();
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