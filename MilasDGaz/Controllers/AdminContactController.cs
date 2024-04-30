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
      
        // GET: AdminBooking
        MilasDogalgazEntities db = new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var valeu = db.Contacts.ToList();
            return View(valeu);
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.Contacts.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var value = db.Contacts.Find(contact.Id);
            value.NameSurname = contact.NameSurname;
            value.Phone = contact.Phone;
            value.Message = contact.Message;
            value.Subject = contact.Subject;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.Contacts.Find(id);
            db.Contacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
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