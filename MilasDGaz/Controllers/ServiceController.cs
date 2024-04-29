using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            ViewBag.Title = "Milas Gaz Mühendislik";
            return View();
        }
        public ActionResult HeaderStart()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Booking()
        {
            return View();
        }
        public ActionResult Testimonial()
        {
            return View();
        }
    }
}