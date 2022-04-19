using System;

using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management.Models;
using Newtonsoft.Json;

namespace Library_Management.Controllers
{

    public class ReturnBookController : Controller
    {
        LMSEntities db1 = new LMSEntities();
        // GET: ReturnBook

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMid(int Order_Id)
        {
            var OrderId = (from s in db1.Order_Book
                           where s.Order_Id == Order_Id

                           select new
                           {
                               
                               Return_Date = s.Return_Date,
                               Book_Name = s.Book_Name,
                               ElapsedDay = SqlFunctions.DateDiff("day", s.Return_Date, DateTime.Now)
                           }).ToArray();

            return Json(OrderId, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Save(Return_Book ret)
        {
            if(ModelState.IsValid)
            {

                db1.Return_Book.Add(ret);
                db1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ret);
        }

    }

}
