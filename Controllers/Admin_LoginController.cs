using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management.Models;

namespace RegandLogin.Controllers
{
    public class Admin_LoginController : Controller
    {
        LMSEntities db1 = new LMSEntities();

        // GET: Admin_Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin objcheck)
        {

            if (ModelState.IsValid)
            {
                using (LMSEntities db1 = new LMSEntities())
                {
                    var obj = db1.Admins.Where(a => a.Admin_Name.Equals(objcheck.Admin_Name) && a.Admin_Password.Equals(objcheck.Admin_Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["Admin_Id"] = obj.Admin_id.ToString();
                        Session["Admin_Name"] = obj.Admin_Name.ToString();
                        return RedirectToAction("Index", "Admins");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect UserName or Password");

                    }
                }
            }

            return View(objcheck);

        }
    }
}
