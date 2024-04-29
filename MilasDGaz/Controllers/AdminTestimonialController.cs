using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminTestimonialController : Controller
    {
        // GET: AdminTestimonial
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var valeu=db.Testimonials.ToList();
            return View(valeu);
        }
        [HttpGet]
        public ActionResult AddRef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRef(Testimonial testimonial)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string Pathh = Path.GetExtension(Request.Files[0].FileName);
                string adress = "~/Images/" + fileName + Pathh;
                Request.Files[0].SaveAs(Server.MapPath(adress));
                testimonial.İmageUrl = "~/Images/" + fileName + Pathh;
               
            }
            db.Testimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateRef(int id)
        {
            var value = db.Testimonials.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateRef(Testimonial testimonial)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string Pathh = Path.GetExtension(Request.Files[0].FileName);
                string adress = "~/Images/" + fileName + Pathh;
                Request.Files[0].SaveAs(Server.MapPath(adress));
                testimonial.İmageUrl = "~/Images/" + fileName + Pathh;

            }
            var value = db.Testimonials.Find(testimonial.Id);
            value.Comment= testimonial.Comment;
            value.NameSurname= testimonial.NameSurname;
            value.Location= testimonial.Location;
            value.İmageUrl = testimonial.İmageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRef(int id)
        {
            var value = db.Testimonials.Find(id);
            db.Testimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}