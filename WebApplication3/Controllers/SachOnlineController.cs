using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SachOnlineController : Controller
    {
        QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: SachOnline
        public ActionResult Index()
        {
            /*var lstSach = from s in db.SACHes
                          join cd in db.CHUDEs on s.MaCD equals cd.MaCD
                          join nxb in db.NHAXUATBANs on s.MaNXB equals nxb.MaNXB
                          select new {s.MaSach, s.MaCD, s.MaNXB, cd.TenChuDe, nxb.TenNXB};*/

            //var lstSach = from s in db.SACHes select new { s.MaCD, s.TenSach};



            /* var lstSach = db.SACHes.Join(db.CHUDEs, s => s.MaCD, cd => cd.MaCD, (s, cd) => new { s, cd })
               .Join(db.NHAXUATBANs, scd => scd.s.MaNXB, nxb => nxb.MaNXB, (scd, nxb) =>
               new { scd.s.MaSach, scd.s.TenSach, scd.cd.TenChuDe, nxb.TenNXB }).ToList();*/



            //var lstSach = db.SACHes.Select(
            // s => new { s.MaSach, s.TenSach, s.CHUDE.TenChuDe, s.NHAXUATBAN.TenNXB }).ToList();



            /*var lstTKCD = (from s in db.SACHes
                          group s by s.MaCD into g
                          select new
                          {
                              MaCD = g.Key.ToString(),
                              Count = g.Count(),
                              TenChuDe = g.Select(s => s.CHUDE.TenChuDe),
                              Sum = g.Sum(s => s.SoLuongBan),
                              Min = g.Min(s =>  s.SoLuongBan),
                              Max = g.Max(s => s.SoLuongBan),
                          }).ToList(); */


            /*var lstTKCD = db.SACHes.GroupBy(s => s.MaCD).Join(db.CHUDEs, g => g.Key, cd => cd.MaCD, (g, cd) =>
            new { g, cd.TenChuDe })
                .Select(tk => new
                {
                    MaCD = tk.g.Key.ToString(),
                    TenCD = tk.TenChuDe.ToString(),
                    Count = tk.g.Count(),
                    Sum = tk.g.Sum(s => s.SoLuongBan),
                    Min = tk.g.Min(s => s.SoLuongBan),
                    Max = tk.g.Max(s => s.SoLuongBan),
                }).ToList();*/
            var lstTKCD = db.SACHes.GroupBy(s => s.CHUDE)
                .Select(g => new
                {
                    MaCD = g.Key.MaCD,
                    TenCD = g.Key.TenChuDe,
                    Count = g.Count(),
                    Sum = g.Sum(s => s.SoLuongBan),
                    Min = g.Min(s => s.SoLuongBan),
                    Max = g.Max(s => s.SoLuongBan),
                }).ToList();
            return View(lstTKCD);
        }
    }
}