using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MilasDGaz.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        MilasDogalgazEntities db = new MilasDogalgazEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Milas Gaz Mühendislik";
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Booking book)
        {
            if (ModelState.IsValid)
            {
                book.Statu = false;
                db.Bookings.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
              /*  return Json(new { success = true, redirectUrl = Url.Action("Index", "About") })*/;
                // Tam sayfa yenilemesi yaparak Index sayfasına yönlendirme
                
            }

            // Eğer ModelState geçerli değilse, yani form doğrulaması başarısız olursa, aynı kısmi görünümü döndürün.
            return PartialView();
        }
       
    }
}