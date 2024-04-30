using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Image imageModel = new Image();
            using (MilasDogalgazEntities db = new MilasDogalgazEntities())
            {
                imageModel = db.Images.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(imageModel);
        }
    }
}