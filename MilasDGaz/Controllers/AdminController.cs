using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MilasDGaz.Models;
using System.IO;

namespace MilasDGaz.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MilasDogalgazEntities db=new MilasDogalgazEntities();
     
        public ActionResult Index()
        {
            var value=db.Abouts.ToList();
            return View(value);
        }
        
        public PartialViewResult AdminLayoutSideBar()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }
      
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            string fileName = Path.GetFileNameWithoutExtension(about.ImageFile.FileName);
            string extension = Path.GetExtension(about.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            about.Image1 = "~/Images/" + fileName;
            about.Image2 = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            about.ImageFile.SaveAs(fileName);

            db.Abouts.Add(about);
            db.SaveChanges();

            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id) 
        {
            var value=db.Abouts.Find(id);
            return View(value);
            
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            string fileName = Path.GetFileNameWithoutExtension(about.ImageFile.FileName);
            string extension = Path.GetExtension(about.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            about.Image1 = "~/Images/" + fileName;
            about.Image2 = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            about.ImageFile.SaveAs(fileName);

            var value = db.Abouts.Find(about.Id);
            value.Title = about.Title;
            value.Description = about.Description;
            value.Item1 = about.Item1;
            value.Item2 = about.Item2;
            value.Item3 = about.Item3;
            value.Image1= about.Image1;
            value.Image2= about.Image2;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value= db.Abouts.Find(id);
            db.Abouts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}