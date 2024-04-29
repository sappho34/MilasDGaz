using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        MilasDogalgazEntities db=new MilasDogalgazEntities();   
        public ActionResult Index()
        {
            ViewBag.Title = "Milas Mühendislik";
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public PartialViewResult About()
        {
            var value=db.Abouts.ToList();
            return PartialView(value);
        }
        public PartialViewResult State()
        {
            return PartialView();
        }
        public PartialViewResult Team()
        {
            return PartialView();
        }
        public PartialViewResult Services()
        {
            return PartialView();
        }
        public PartialViewResult Contact()
        {
            var value = db.Us.ToList();
            return PartialView(value);
        }

    }
}