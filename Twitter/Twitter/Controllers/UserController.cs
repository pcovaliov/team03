using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Models;
using Twitter.CRUD;

namespace Twitter.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

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
                UserCRUD AddingUser = new UserCRUD();
                if (AddingUser.Add(CurrentUser))
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel CurrentUser)
        {

            UserCRUD loginUser = new UserCRUD();
            if (loginUser.Login(CurrentUser))
            {
                this.Session["LogedFirstName"] = CurrentUser.FirstName;
                ViewBag.Message = "Successfully Loged.";
            }
            else
            {
                //return RedirectToAction("Login");
                ViewBag.Message = "Login Failed.";
               
            }
            return View();
        }

    }
}

