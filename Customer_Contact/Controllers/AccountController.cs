using Customer_Contact.Models;
using Domain;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Customer_Contact.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserModel userModel = (UserModel)UserDomain.GetUserAuthentication(model.Login, model.Password);

            if (userModel != null)
            {
                FormsAuthentication.SetAuthCookie(userModel.Id.ToString(), false);

                var authTicket = new FormsAuthenticationTicket(1, userModel.Id.ToString(), DateTime.Now, DateTime.Now.AddMinutes(20), false, userModel.Role.Name);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction(userModel.Role.IsAdmin ? "ListAdmin" : "ListSeller", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "The e-mail and / or password entered is invalid. Please try again.");
                return View(model);
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}