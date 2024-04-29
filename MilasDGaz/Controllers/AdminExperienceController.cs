using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminExperienceController : Controller
    {
        // GET: Experience
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var valeu = db.Experiences.ToList();
            return View(valeu);
        }
        [HttpGet]
        public ActionResult AddExp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExp(Experience exp)
        {
            db.Experiences.Add(exp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExp(int id)
        {
            var value = db.Experiences.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateExp(Experience exp)
        {
            var value = db.Experiences.Find(exp.Id);
            value.Icon = exp.Icon;
            value.Title= exp.Title;
            value.Description= exp.Description;
            value.Item1 = exp.Item1;
            value.Item2 = exp.Item2;
            value.Item3 = exp.Item3;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExp(int id)
        {
            var value = db.Experiences.Find(id);
            db.Experiences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}