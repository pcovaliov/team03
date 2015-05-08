using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.BL;
using Twitter.Model;
using PagedList;
using PagedList.Mvc;
using Twitter.CRUD.CRUD;

namespace Twitter.WEB.Controllers
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
                UserBL newUser = new UserBL();
                if (newUser.Register(CurrentUser))
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
               UserBL loginUser = new UserBL();
               int userLogedId = loginUser.Login(CurrentUser);
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
            UserBL users = new UserBL();
            allUsers = users.SelectUsers().OrderBy(currentUser => currentUser.IdUser).ToList();
            return View("DisplayUsers", allUsers.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Edit(int item)
        {
            UserBL editUser = new UserBL();
            var currentUser = editUser.EditUser(item);
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
            UserBL changeUser = new UserBL();
            if (changeUser.EditUser(currentUser))
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
            UserBL deletedUser = new UserBL();
            if (deletedUser.DeleteUser(item))
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
