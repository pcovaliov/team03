using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Services;
using Twitter.Models;
using PagedList;
using PagedList.Mvc;
using log4net;
using System.Web.Security;

namespace Twitter.WEB.Controllers
{
    
    public class UserController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(UserController));
        #region Private
        public IUserService UserService { get; set; }
        #endregion

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserModel CurrentUser, HttpPostedFileBase Avatar)
        {

            if (ModelState.IsValid)
            {
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Avatar.FileName);

                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    Avatar.SaveAs(path);
                    CurrentUser.Avatar = fileName;
                }

                if (UserService.Register(CurrentUser))
                {
                    log.Info("Registrated succesfuly " + CurrentUser.Email);
                    ViewBag.Message = "Successfully Registration Done.";
                    return RedirectToAction("Login");
                }
                else
                {
                    log.Info("Registration failed " + CurrentUser.Email);
                    ViewBag.Message = "Registration Failed, this mail is already used.";
                }

            }


            return View(CurrentUser);

        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserModel CurrentUser)
        {
                int userLogedId = UserService.Login(CurrentUser);
                if (userLogedId > 0)
                {
                    FormsAuthentication.SetAuthCookie(CurrentUser.ConfirmPassword, false);                   
                    this.Session["LogedId"] = userLogedId.ToString();
                    this.Session["LogedName"] = CurrentUser.Email.ToString();
                    if (CurrentUser.Email == "admin@endava.com")
                    {
                        this.Session["AreAdmin"] = "Yes";
                    }
                    else
                    {
                        this.Session["AreAdmin"] = "No";
                    }
                    log.Info("Succesful loged " + CurrentUser.Email);
                    return RedirectToAction("DisplayUsers");
                }
                else
                {
                    log.Info("Login failed " + CurrentUser.Email);
                    ViewBag.Message = "Login Failed.";
                }
            return View();
        }
        [Authorize]
        public ActionResult DisplayUsers(int? page = 1)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<UserModel> allUsers = new List<UserModel>();
            allUsers = UserService.SelectUsers().OrderByDescending(currentUser => currentUser.IdUser).ToList();
            log.Info("Displayed users succesfuly");
            return View("DisplayUsers", allUsers.ToPagedList(pageNumber, pageSize));
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int item)
        {
            var currentUser = UserService.GetUser(item);
            if (currentUser != null)
            {
                return View(currentUser);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(UserModel currentUser)
        {
            if (UserService.EditUser(currentUser))
            {
                log.Info("User edited succesfuly " + currentUser.Email);
                return RedirectToAction("DisplayUsers");
            }
            else
            {
                return View(currentUser);
            }
        }
        [Authorize]
        public ActionResult Delete(int item)
        {
            if (UserService.DeleteUser(item))
            {
                log.Info("User deleted succesfuly, id=" + item);
                return RedirectToAction("DisplayUsers");
            }
            else
            {
                return View();
            }

        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
