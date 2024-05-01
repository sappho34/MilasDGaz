using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminTeamController : Controller
    {
        // GET: AdminTeam
        MilasDogalgazEntities db=new MilasDogalgazEntities();
        public ActionResult Index()
        {
            var valeu = db.Teams.ToList();
            return View(valeu);
        }
        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeam(Team team)
        {
            //if (Request.Files.Count > 0)
            //{
            //    string fileName = Path.GetFileName(Request.Files[0].FileName);
            //    string Pathh = Path.GetExtension(Request.Files[0].FileName);
            //    string adress = "~/Images/" + fileName + Pathh;
            //    Request.Files[0].SaveAs(Server.MapPath(adress));
            //    team.ImageUrl = "~/Images/" + fileName;

            //}
            //db.Teams.Add(team);
            //db.SaveChanges();
            string fileName = Path.GetFileNameWithoutExtension(team.ImageFile.FileName);
            string extension = Path.GetExtension(team.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            team.ImageUrl = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            team.ImageFile.SaveAs(fileName);

            db.Teams.Add(team);
             db.SaveChanges();
            
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var value = db.Teams.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateTeam(Team team)
        {
            //if (Request.Files.Count > 0)
            //{
            //    string fileName = Path.GetFileName(Request.Files[0].FileName);
            //    string Pathh = Path.GetExtension(Request.Files[0].FileName);
            //    string adress = "~/Images/" + fileName + Pathh;
            //    Request.Files[0].SaveAs(Server.MapPath(adress));
            //    team.ImageUrl = "~/Images/" + fileName ;

            //}
            string fileName = Path.GetFileNameWithoutExtension(team.ImageFile.FileName);
            string extension = Path.GetExtension(team.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            team.ImageUrl = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            team.ImageFile.SaveAs(fileName);

            var value = db.Teams.Find(team.Id);
            value.Icon1= team.Icon1;
            value.NameSurname = team.NameSurname;
            value.Icon2= team.Icon2;
            value.Icon3= team.Icon3;    
            value.ImageUrl=team.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTeam(int id)
        {
            var value = db.Teams.Find(id);
            db.Teams.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}