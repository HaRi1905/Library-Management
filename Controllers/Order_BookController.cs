using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_Management.Models;

namespace Library_Management.Controllers
{
    public class Order_BookController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: Order_Book
        public ActionResult Index()
        {
            var order_Book = db.Order_Book.Include(o => o.Book);
            return View(order_Book.ToList());
        }

        // GET: Order_Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Book order_Book = db.Order_Book.Find(id);
            if (order_Book == null)
            {
                return HttpNotFound();
            }
            return View(order_Book);
        }

        // GET: Order_Book/Create
        public ActionResult Create()
        {
            ViewBag.Book_Name = new SelectList(db.Books, "Book_Name", "Book_Name");
            return View();
        }

        // POST: Order_Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Id,user_id,Book_Name,Issue_Date,Return_Date")] Order_Book order_Book)
        {
            if (ModelState.IsValid)
            {
                db.Order_Book.Add(order_Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_Name = new SelectList(db.Books, "Book_Name", "Book_Name", order_Book.Book_Name);
            return View(order_Book);
        }

        // GET: Order_Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Book order_Book = db.Order_Book.Find(id);
            if (order_Book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_Name = new SelectList(db.Books, "Book_Name", "Book_Name", order_Book.Book_Name);
            return View(order_Book);
        }

        // POST: Order_Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Id,user_id,Book_Name,Issue_Date,Return_Date")] Order_Book order_Book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_Name = new SelectList(db.Books, "Book_Name", "Book_Name", order_Book.Book_Name);
            return View(order_Book);
        }

        // GET: Order_Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Book order_Book = db.Order_Book.Find(id);
            if (order_Book == null)
            {
                return HttpNotFound();
            }
            return View(order_Book);
        }

        // POST: Order_Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Book order_Book = db.Order_Book.Find(id);
            db.Order_Book.Remove(order_Book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
