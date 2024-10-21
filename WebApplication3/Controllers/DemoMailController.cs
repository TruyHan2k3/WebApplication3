using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DemoMailController : Controller
    {
        // GET: DemoMail
        public ActionResult Index()
        {
            List<Mail> mails = new List<Mail>
            {
                new Mail
                {
                    To = "huytran031103@gmail.com",
                    Subject = "Hello"
                },
                new Mail
                {
                    To = "tranhuy2k3ss@gmail.com",
                    Subject= "Xin Chào"
                }
            };
            ViewBag.mails = new SelectList(mails, "To", "Subject");

            return View();
        }
    }
}