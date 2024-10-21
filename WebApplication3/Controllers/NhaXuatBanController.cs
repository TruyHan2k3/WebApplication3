using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class NhaXuatBanController : Controller
    {
        QLBANSACHEntities db = new QLBANSACHEntities();
        // GET: NhaXuatBan
        public ActionResult Index()
        {
            var lstNXB = db.NHAXUATBANs.ToList();
            return View(lstNXB);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NHAXUATBAN newNXB)
        {
            if (ModelState.IsValid)
            {
                db.NHAXUATBANs.Add(newNXB);
                db.SaveChanges();       
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpPost]
        public ActionResult Delete (int id)
        {
            var nxb = db.NHAXUATBANs.FirstOrDefault(n => n.MaNXB == id);
            db.NHAXUATBANs.Remove(nxb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var nxb = db.NHAXUATBANs.Find(id);
            if (nxb == null)
            {
                return HttpNotFound();
            }
            return View(nxb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NHAXUATBAN nxb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nxb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nxb);
        }

        public ActionResult Details(int id)
        {
            var nxb = db.NHAXUATBANs.Find(id);
            if (nxb == null)
            {
                return HttpNotFound();
            }
            return View(nxb);
        }

    }
}