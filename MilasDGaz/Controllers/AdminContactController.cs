using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminContactController : Controller
    {
        // GET: AdminContact
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var value = db.Contacts.ToList();
            return View(value);
        }
        public ActionResult DeleteContact(int id)
        {
            var item=db.Contacts.Find(id);
            db.Contacts.Remove(item);
            db.SaveChanges();
            return View("Index");
        }
   
        public ActionResult ChangeContact(int id)
        {
            var item = db.Contacts.Find(id);
            if (item.Status == null || item.Status == false)
            {

                item.Status = true;
            }
            else
            {
                item.Status = false;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}