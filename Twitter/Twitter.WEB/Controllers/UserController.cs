using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Services;
using Twitter.Models;
using PagedList;
using PagedList.Mvc;

namespace Twitter.WEB.Controllers
{
    public class UserController : Controller
    {
        #region Private
        public IUserService UserService { get; set; }
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
                 if (UserService.Register(CurrentUser))
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
            int userLogedId = UserService.Login(CurrentUser);
            if (userLogedId > 0)
            {
                this.Session["LogedId"] = userLogedId.ToString();
                this.Session["LogedName"] = CurrentUser.Email.ToString();
                return RedirectToAction("DisplayUsers");
            }
            else
            {
                ViewBag.Message = "Login Failed.";
            }
            return View();
        }

        public ActionResult DisplayUsers(int? page = 1)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<UserModel> allUsers = new List<UserModel>();
            allUsers = UserService.SelectUsers().OrderByDescending(currentUser => currentUser.IdUser).ToList();
            return View("DisplayUsers", allUsers.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
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
        public ActionResult Edit(UserModel currentUser)
        {
            if (UserService.EditUser(currentUser))
            {
                return RedirectToAction("DisplayUsers");
            }
            else
            {
                return View(currentUser);
            }
        }

        public ActionResult Delete(int item)
        {
            if (UserService.DeleteUser(item))
            {
                return RedirectToAction("DisplayUsers");
            }
            else
            {
                return View();
            }

        }

    }
}
