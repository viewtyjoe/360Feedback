using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace _360Feedback.Controllers
{
    public class SendEmailController : Controller
    {
        // GET: SendEmail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(_360Feedback.Models.EmailModel _objModelMail)
        {
            if(ModelState.IsValid) {
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
                
            }else{
                return View();
            }
      }

    }
}