using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminPasswordController : Controller
    {
        // GET: AdminPassword
        MilasDogalgazEntities db = new MilasDogalgazEntities();
        [Authorize]
        public ActionResult Index()
        {
            var valeu = db.UserLogins.ToList();
            return View(valeu);
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPass(UserLogin user)
        {
            db.UserLogins.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var value = db.UserLogins.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateUser(UserLogin user)
        {
            var value = db.UserLogins.Find(user.Id);
            value.UserName = user.UserName;
           
            value.Password =user.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id)
        {
            var value = db.UserLogins.Find(id);
            db.UserLogins.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}