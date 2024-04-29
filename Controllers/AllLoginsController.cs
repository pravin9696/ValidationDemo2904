using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationDemo2904.Models;

namespace ValidationDemo2904.Controllers
{
    public class AllLoginsController : Controller
    {
        // GET: AllLogins
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(classLoginModel lgm)
        {
            if (string.IsNullOrEmpty(lgm.userid))
            {
                ModelState.AddModelError("userid", "Enter user ID");
            }
            if(string.IsNullOrEmpty(lgm.password))
            {
                ModelState.AddModelError("password", "Enter password");
            }
            if (ModelState.IsValid)
            {
                StudMgtEntity sme = new StudMgtEntity();
                var lg = sme.tblLogins.FirstOrDefault(x=>x.userid==lgm.userid && x.password==lgm.password);
                if (lg != null)
                {
                    ViewBag.msg = "Invalid user id or password";
                    return View();
                }
                else
                     return RedirectToAction("index");
            }
            else
            {
                return View();
            }
            
        }
    }
}