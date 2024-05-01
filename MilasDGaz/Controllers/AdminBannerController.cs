using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminBannerController : Controller
    {
        // GET: AdminBanner
        MilasDogalgazEntities db = new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var valeu = db.Banners.ToList();
            return View(valeu);
        }
        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Banner banner)
        {
            //if (Request.Files.Count > 0)
            //{
            //    string fileName = Path.GetFileName(Request.Files[0].FileName);
            //    string Pathh = Path.GetExtension(Request.Files[0].FileName);
            //    string adress = "~/Images/" + fileName + Pathh;
            //    Request.Files[0].SaveAs(Server.MapPath(adress));
            //    banner.ImageUrl = "~/Images/" + fileName + Pathh;

            //}
            string fileName = Path.GetFileNameWithoutExtension(banner.ImageFile.FileName);
            string extension = Path.GetExtension(banner.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            banner.ImageUrl = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            banner.ImageFile.SaveAs(fileName);
            db.Banners.Add(banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = db.Banners.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            
            var value = db.Banners.Find(banner.Id);

            //if (Request.Files.Count > 0)
            //{
            //    string fileName = Path.GetFileName(Request.Files[0].FileName);
            //    string Pathh = Path.GetExtension(Request.Files[0].FileName);
            //    string adress = "~/Images/" + fileName + Pathh;
            //    Request.Files[0].SaveAs(Server.MapPath(adress));
            //    banner.ImageUrl = "~/Images/" + fileName + Pathh;

            //}
            string fileName = Path.GetFileNameWithoutExtension(banner.ImageFile.FileName);
            string extension = Path.GetExtension(banner.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            banner.ImageUrl = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            banner.ImageFile.SaveAs(fileName);
            value.ImageUrl = banner.ImageUrl;
            value.Description = banner.Description;
            value.Title = banner.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBanner(int id)
        {
            var value = db.Banners.Find(id);
            db.Banners.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
     
    }
}