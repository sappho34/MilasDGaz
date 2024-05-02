using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.Services.Description;


namespace MilasDGaz.Controllers
{
    public class AccountController : Controller
    {
        // GET: Acount
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Index(UserLogin login)
        {
            MilasDogalgazEntities db = new MilasDogalgazEntities();
            var adminUserInfo = db.UserLogins.FirstOrDefault(x => x.UserName == login.UserName &&
            x.Password == login.Password);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.UserName, false);
                Session["UserName"] = adminUserInfo.UserName.ToString();
                return RedirectToAction("Index", "AdminBooking");
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
            //if (ModelState.IsValid)
            //{
            //    var r = getUser(login.UserName);
            //    if (r == null)
            //    {
            //        TempData["msg"] = "Ulaşılamdı";
            //        return View();
            //    }
            //    else
            //    {
            //        if(r.UserName==login.UserName && r.Password == login.Password)
            //        {
            //            Session["userId"]=r.UserName;
            //            FormsAuthentication.SetAuthCookie(r.Id, false);
            //            return RedirectToAction("Index", "AdminBooking");
            //        }
            //    }
            //}
        }
    }
}