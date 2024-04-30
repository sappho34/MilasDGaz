using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace MilasDGaz.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MilasDogalgazEntities db=new MilasDogalgazEntities();

      
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin admin)
        {
            var value = db.UserLogins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["userName"] = value.UserName;// giriş yapılca kapanan kadar tutuyor
                return RedirectToAction("Index", "AdminBooking");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                return View();
            }

        }

       
    }
}