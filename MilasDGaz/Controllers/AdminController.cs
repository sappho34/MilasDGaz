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
            if(Request.Files.Count>0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string Pathh = Path.GetExtension(Request.Files[0].FileName);
              
                string patika = "~/Images/" + fileName + Pathh;
                Request.Files[0].SaveAs(Server.MapPath(patika));
                about.Image1= "~/Images/" + fileName+patika ;
                about.Image2= "~/Images/" + fileName+patika ;
            }
            
            db.Abouts.Add(about);
            db.SaveChanges();
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
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string Pathh = Path.GetExtension(Request.Files[0].FileName);
                string adress = "~/Images/" + fileName + Pathh;
                Request.Files[0].SaveAs(Server.MapPath(adress));
                about.Image1 = "~/Images/" + fileName + Pathh;
                about.Image2 = "~/Images/" + fileName + Pathh;
            }

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