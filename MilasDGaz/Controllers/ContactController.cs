using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        public ActionResult Index()
        {

            return View();
        }
      
        
        [HttpGet]
        public PartialViewResult SendMessage()
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Status = false;
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView();
        }
      
    }
}