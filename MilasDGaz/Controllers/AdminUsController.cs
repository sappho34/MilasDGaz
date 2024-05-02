using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminUsController : Controller
    {
        // GET: AdminUs
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        [Authorize]
        public ActionResult Index()
        {
            var value=db.Us.ToList();
            return View(value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUs(Us us) { 

            db.Us.Add(us);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateUs(int id)
        {
            var value = db.Us.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateUs(Us us)
        {
            var value = db.Us.Find(us.Id);
            value.Adress = us.Adress;
            value.Phone1= us.Phone1;
            value.Phone=us.Phone;
            value.Phone2= us.Phone2;
            value.Email=us.Email;
            
            value.Fax=us.Fax;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUs(int id)
        {
            var value = db.Us.Find(id);
            db.Us.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}