using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(MailInfo model)
        {
            var mail = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new NetworkCredential("22280201e0046@student.tdmu.edu.vn", "ofqu sioy zikw icgt"),
                EnableSsl = true
            };
            var message = new MailMessage();
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(model.To);
            message.Subject = model.Subject;
            message.Body = model.Body;

            // Xử lý tệp đính kèm
            if (model.Attachments != null && model.Attachments.Count > 0)
            {
                foreach (var file in model.Attachments)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        message.Attachments.Add(new Attachment(file.InputStream, fileName));
                    }
                }
            }

            mail.Send(message);
            return View("Index");
        }

    }
}