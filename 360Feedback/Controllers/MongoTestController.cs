using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoLabUtils;
using _360Feedback.Models;
using _360Feedback.DataContexts;

namespace _360Feedback.Controllers
{
    public class MongoTestController : Controller
    {
        private MongoApi Db = new MongoApi { Database = "wctc-360-feedback", ApiKey = "oHIeU1xIFPhPKDrXzkO90gQTWe7wyswW" };
        private FeedbackDb SqlDb = new FeedbackDb();
        // GET: MongoTest
        public ActionResult Index()
        {
            //string uri = "mongodb://admin:admin@ds049211.mongolab.com:49211/wctc-360-feedback";
            
            //MongoUrl mongoUrl = new MongoUrl(uri);
            //MongoClient client = new MongoClient(mongoUrl);
            //TimeSpan span = client.Settings.ConnectTimeout;
            //MongoServer server = client.GetServer();
            //MongoDatabase database = server.GetDatabase(mongoUrl.DatabaseName);

            //var db = database.GetCollection<BsonDocument>("questions").FindAll();

            //string url = "https://api.mongolab.com/api/1/databases/wctc-360-feedback/";
            //string key = "oHIeU1xIFPhPKDrXzkO90gQTWe7wyswW";

            //var client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = await Db.SelectAll("questions");
            //if(response.IsSuccessStatusCode)
            //{
            //    List<Question> questions = await HttpContentExtensions.ReadAsAsync<List<Question>>(response.Content);

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
            //    questions.Reverse();
            //    return View(questions);
            //}

            List<Question> Questions = SqlDb.Questions.ToList();

            return View(Questions);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(TestModel test)
        {
            if(test != null)
            {
                HttpResponseMessage response = await Db.Write("testing", test);
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Add");
        }
    }
}