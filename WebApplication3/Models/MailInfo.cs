using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class MailInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public List<HttpPostedFileBase> Attachments { get; set; } // Chấp nhận nhiều tệp đính kèm
    }

}