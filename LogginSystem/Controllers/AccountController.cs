using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogginSystem.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
using System.Web.Security;
using Limilabs.Client.Authentication.Google;

namespace LogginSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult verify(Account acc)
        {
            string message = "";
            using(MyDatabaseEntities dc =new MyDatabaseEntities())
            {
                var v = dc.Users.Where(a => a.EmailID == acc.Name).FirstOrDefault();
                if (v != null)
                {
                    Session["EmailID"] = v.EmailID.ToString();
                    Session["password"] = v.Password.ToString();
                    return RedirectToAction("Name");
                }
                else
                {
                    message = "Invalid credintal provided";
                }
            }
            ViewBag.Message = message;
            return View(User);
        }
        public ActionResult Name()
        {
              if (Session["EmailID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}