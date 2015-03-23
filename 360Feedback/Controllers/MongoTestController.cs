using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using _360Feedback.Models;

namespace _360Feedback.Controllers
{
    public class MongoTestController : Controller
    {
        // GET: MongoTest
        public ActionResult Index()
        {
            string uri = "mongodb://admin:admin@ds049211.mongolab.com:49211/wctc-360-feedback";
            
            MongoUrl mongoUrl = new MongoUrl(uri);
            MongoClient client = new MongoClient(mongoUrl);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase(mongoUrl.DatabaseName);

            var db = database.GetCollection<BsonDocument>("questions").FindAll();

            var questions = new List<Question>();

            foreach(var document in db)
            {
                Question question = new Question();
                List<Category> categories = new List<Category>();
                question.title = document.GetElement("title").ToString();
                foreach(var category in document.GetElement("categories").Value.AsBsonArray)
                {
                    Category addCategory = new Category();
                    var categoryDoc = category.ToBsonDocument();
                    addCategory.name = categoryDoc.GetElement("name").ToString();
                    List<string> values = new List<string>();
                    foreach(var value in categoryDoc.GetElement("values").Value.AsBsonArray)
                    {
                        values.Add(value.ToString());
                    }
                    addCategory.values = values;
                    categories.Add(addCategory);
                }
                question.categories = categories;
                questions.Add(question);
            }

            return View(questions);
        }

  
    }
}