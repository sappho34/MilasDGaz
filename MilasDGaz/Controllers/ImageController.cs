using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            //string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            //string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //imageModel.ImagePath = "~/Images/" + fileName;
            //fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            //imageModel.ImageFile.SaveAs(fileName);
            //using (MilasDogalgazEntities db=new MilasDogalgazEntities())
            //{
            //    db.Images.Add(imageModel);
            //    db.SaveChanges();
            //}
            ModelState.Clear();
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
        public ActionResult Index()
        {
            using (MilasDogalgazEntities db = new MilasDogalgazEntities())
            {
                return View(db.Images.ToList());
            }
        }
    }
}