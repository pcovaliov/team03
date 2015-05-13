using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Services;
using Twitter.Models;

namespace Twitter.WEB.Controllers
{
    public class UserController : Controller
    {
        #region Private
        IUserService iUserService { get; set; }
        #endregion
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel CurrentUser)
        {
            if (ModelState.IsValid)
            {
                if (iUserService.Register(CurrentUser))
                {
                    ViewBag.Message = "Successfully Registration Done.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Message = "Registration Failed, this mail is already used.";
                }
            }
            return View(CurrentUser);
        }

    }
}
