using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.BL;
using Twitter.Model;
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
                    //return RedirectToAction("Login");
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

        public ActionResult DisplayUsers(int page = 1)
        {
            int pageSize = 10;
            int totalPage = 0;
            int totalRecord = 0;

            List<UserModel> allUsers = new List<UserModel>();
            UserBL users = new UserBL();

            totalRecord = users.SelectUsers().Count();
            allUsers = users.SelectUsers().OrderBy(a => a.IdUser).Skip(((page - 1) * pageSize)).Take(pageSize).ToList();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            ViewBag.TotalRows = totalRecord;
            ViewBag.PageSize = pageSize;

            return View(allUsers);
        }

    }
}
