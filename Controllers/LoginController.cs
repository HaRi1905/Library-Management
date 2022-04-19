using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management.Models;

namespace RegandLogin.Controllers
{
    public class LoginController : Controller
    {
        LMSEntities db = new LMSEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(new_User objchk)
        {
            if (ModelState.IsValid)
            {
                using (LMSEntities db = new LMSEntities())
                {
                    var obj = db.new_User.Where(a => a.user_name.Equals(objchk.user_name) && a.Password.Equals(objchk.Password)).FirstOrDefault();
                    if (obj !=null)
                    {
                        Session["UserId"] = obj.user_id.ToString();
                        Session["UserName"] = obj.user_name.ToString();
                        return RedirectToAction("Index", "ViewBook");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect UserName or Password");
                    }
                }
            }
            return View(objchk);
        }
    }

}
