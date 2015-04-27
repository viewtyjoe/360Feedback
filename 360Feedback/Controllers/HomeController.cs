using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using _360Feedback.Models;




namespace _360Feedback.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentView()
        {
            string url = "https://api.mongolab.com/api/1/databases/wctc-360-feedback/";
            string key = "oHIeU1xIFPhPKDrXzkO90gQTWe7wyswW";

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("collections/questions?apiKey=" + key);
            if(response.IsSuccessStatusCode)
            {
                List<Question> questions = await HttpContentExtensions.ReadAsAsync<List<Question>>(response.Content);

                //foreach(var document in db)
                //{
                //    Question question = new Question();
                //    List<Category> categories = new List<Category>();
                //    question.title = document.GetElement("title").ToString();
                //    foreach(var category in document.GetElement("categories").Value.AsBsonArray)
                //    {
                //        Category addCategory = new Category();
                //        var categoryDoc = category.ToBsonDocument();
                //        addCategory.name = categoryDoc.GetElement("name").ToString();
                //        List<string> values = new List<string>();
                //        foreach(var value in categoryDoc.GetElement("values").Value.AsBsonArray)
                //        {
                //            values.Add(value.ToString());
                //        }
                //        addCategory.values = values;
                //        categories.Add(addCategory);
                //    }
                //    question.categories = categories;
                //    questions.Add(question);
                //}
                questions.Reverse();
                return View(questions);
            }
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("EmailIndex.cshtml");
        }

        [HttpPost]
        public ActionResult SendEmail(EmailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress("wctcemailtest@gmail.com");
                // mail.From = new MailAddress("MGreen14@wctc.edu");
                mail.Subject = "ISP Team Review";
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                //smtp.Host = "smtp.office365.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("wctcemailtest@gmail.com", "blackrose7");
                // smtp.Credentials = new System.Net.NetworkCredential("MGreen14@wctc.edu", "PASSWORD");
                smtp.EnableSsl = true;
                smtp.Send(mail);


                return View("Index", _objModelMail);

            }
            else
            {
                return View();
            }

        }

    }
}