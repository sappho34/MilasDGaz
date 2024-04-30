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
            ViewBag.Title = "Milas Mühendislik";
            return View();
        }
       
        public ActionResult SendMessage()
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

                // Tam sayfa yenilemesi yaparak Index sayfasına yönlendirme
                return RedirectToAction("Index");
            }

            // Eğer ModelState geçerli değilse, yani form doğrulaması başarısız olursa, aynı kısmi görünümü döndürün.
            return PartialView();
        }
       
    }
}