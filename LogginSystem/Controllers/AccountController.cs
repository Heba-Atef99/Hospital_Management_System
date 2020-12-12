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
        public ActionResult verify(Account acc ,string ReturnUrl)
        {
            string message = "";
            using(HospitalDbEntities dc =new HospitalDbEntities())
            {
                var v = dc.Users.Where(a => a.EmailID == acc.Name).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(acc.Password), v.Password) == 0)
                    {
                        int tiemout = acc.remmeberme ? 525600 : 1;
                        var ticket = new FormsAuthenticationTicket(acc.Name, acc.remmeberme, tiemout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(tiemout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Indes", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
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