using MilasDGaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilasDGaz.Controllers
{
    public class AdminBookingController : Controller
    {
        // GET: AdminBooking
        MilasDogalgazEntities db = new MilasDogalgazEntities();
        [Authorize]
        public ActionResult Index()
        {
            var valeu = db.Bookings.ToList();
            return View(valeu);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Booking book)
        {
            db.Bookings.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var value = db.Bookings.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateBook(Booking book)
        {
            var value = db.Bookings.Find(book.Id);
            value.NameSurname = book.NameSurname;
            value.Phone= book.Phone;
            value.Date = book.Date;
            value.Description = book.Description;
            value.Subject = book.Subject;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            var value = db.Bookings.Find(id);
            db.Bookings.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ChangeBook(int id)
        {
            var item = db.Bookings.Find(id);
            if (item.Statu == null || item.Statu == false)
            {

                item.Statu = true;
            }
            else
            {
                item.Statu = false;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}