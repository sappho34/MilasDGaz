using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var value=db.Us.ToList();
            return View(value);
        }
    }
}