using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Models
{
    public class HitCounterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Dictionary<string, int> hits = new Dictionary<string, int>();
            string path = filterContext.HttpContext.Server.MapPath("~/LuotTruyCap/Hitcounter.txt");

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] arr = line.Split(':');
                        if (arr.Length == 2)
                        {
                            int count;
                            if (int.TryParse(arr[1], out count))
                            {
                                hits[arr[0]] = count;
                            }
                        }
                    }
                }
            }

            // Cập nhật lượt truy cập cho controller hiện tại
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (hits.ContainsKey(controllerName))
            {
                hits[controllerName]++;
            }
            else
            {
                hits[controllerName] = 1; // Lượt truy cập đầu tiên
            }

            // Ghi lại file
            List<string> result = new List<string>();
            foreach (var h in hits)
            {
                result.Add(h.Key + ":" + h.Value);
            }
            File.WriteAllLines(path, result);

            // Lưu lượt truy cập của controller hiện tại vào ViewBag để hiển thị
            filterContext.Controller.ViewBag.HitCount = hits[controllerName];
        }
    }
}
