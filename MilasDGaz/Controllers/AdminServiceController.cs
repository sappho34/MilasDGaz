using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminServiceController : Controller
    {
        // GET: AdminService
        MilasDogalgazEntities db = new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var valeu = db.Services.ToList();
            return View(valeu);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Service service)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string Pathh = Path.GetExtension(Request.Files[0].FileName);
                string adress = "~/Images/" + fileName + Pathh;
                Request.Files[0].SaveAs(Server.MapPath(adress));
                service.ImageUrl = "~/Images/" + fileName + Pathh;

            }
            db.Services.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.Services.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string Pathh = Path.GetExtension(Request.Files[0].FileName);
                string adress = "~/Images/" + fileName + Pathh;
                Request.Files[0].SaveAs(Server.MapPath(adress));
                service.ImageUrl = "~/Images/" + fileName + Pathh;

            }
            var value = db.Services.Find(service.Id);
            value.ImageUrl = service.ImageUrl;
            value.Title = service.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.Services.Find(id);
            db.Services.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}