using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.DAL;
using Twitter.Models;
using Twitter.Controllers;
using Twitter.CRUD;
using System.Web.SessionState;

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
                if (AddingUser.AddUser(CurrentUser))
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
                Session["ID"] = CurrentUser.IdUser;
                ViewBag.Message = "Successfully Loged.";
                
            }
            else
            {
                return RedirectToAction("Login");
                ViewBag.Message = "Login Failed.";

            }
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Message(TweetModel CurrentTweet)
        {

            TweetCRUD AddingTweet = new TweetCRUD();
            if (AddingTweet.AddTweet(CurrentTweet))
            {
                ViewBag.Message = "Your message  was added successfuly";
                //return RedirectToAction("Message");
            }
            else
            {
                ViewBag.Message = "Failed to add message";
            }
            return View(CurrentTweet);
        }
    }
}

