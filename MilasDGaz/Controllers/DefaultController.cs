using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        public ActionResult Index()
        {
            
            return View();
        }
        public PartialViewResult Testimonial()
        {
            var value=db.Testimonials.ToList();
            return PartialView(value);
        }
        public PartialViewResult Banner()
        {
            var value=db.Banners.ToList();
            return PartialView(value);
        }
        public PartialViewResult Services()
        {
            var value=db.Services.ToList(); 
            return PartialView(value);
        }
        public PartialViewResult About()
        {
            var value=db.Abouts.ToList();
            return PartialView(value);
        }
        public PartialViewResult State()
        {
            var value=db.States.ToList();
            return PartialView(value);
        }
        public PartialViewResult Book()
        {
            var value=db.Bookings.ToList();
            return PartialView(value);
        }
        public PartialViewResult Team()
        {
            var value=db.Teams.ToList();
            return PartialView(value);
        }
        public PartialViewResult Experience() 
        {
            var value=db.Experiences.ToList();  
            return PartialView(value);
        
        }
        public PartialViewResult Footer()
        {
            var value = db.Us.ToList();
            return PartialView(value);

        }
        public PartialViewResult Navb()
        {
            var value = db.Us.ToList();
            return PartialView(value);

        }
        public PartialViewResult NavBar()
        {
            var value = db.Us.ToList();
            return PartialView(value);

        }
        public PartialViewResult FooterService()
        {
            var value = db.Services.ToList();
            return PartialView(value);

        }
        public PartialViewResult FooterSocial()
        {
            var value = db.Services.ToList();
            return PartialView(value);

        }
        public PartialViewResult NavSocial()
        {
            var value = db.Services.ToList();
            return PartialView(value);

        }
        //public PartialViewResult Contact()
        //{
        //    ViewBag.Title = "Milas Gaz Mühendislik";
        //    return PartialView();

        //}
    }
}