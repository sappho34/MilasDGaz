using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminStateController : Controller
    {
        // GET: AdminState
        MilasDogalgazEntities db = new MilasDogalgazEntities();
        [Authorize]
        public ActionResult Index()
        {
            var valeu = db.States.ToList();
            return View(valeu);
        }
        //[HttpGet]
        //public ActionResult AddState()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddState(State state)
        //{
        //    db.States.Add(state);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //
        [Authorize]
        [HttpGet]
        public ActionResult UpdateState(int id)
        {
            var value = db.States.Find(id);
            return View(value);

        }
      
        [HttpPost]
        public ActionResult UpdateState(State state)
        {
            var value = db.States.Find(state.Id);
            value.Title= state.Title;
            value.Value = state.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult DeleteState(int id)
        //{
        //    var value = db.States.Find(id);
        //    db.States.Remove(value);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}