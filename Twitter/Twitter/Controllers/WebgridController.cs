using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.DAL;
using Twitter.Models;
using Twitter.CRUD;

namespace Twitter.Controllers
{
    public class WebgridController : Controller
    {
        //
        // GET: /Webgrid/

        //public ActionResult DisplayUsers()
        //{
        //    return View();
        //}

        public ActionResult DisplayUsers(int page = 1)
        {
            int pageSize = 10;
            int totalPage = 0;
            int totalRecord = 0;

            List<UserModel> allUsers = new List<UserModel>();
            UserCRUD readingUsers = new UserCRUD();



            totalRecord = readingUsers.Read().Count();
            allUsers = readingUsers.Read().OrderBy(a => a.IdUser).Skip(((page - 1) * pageSize)).Take(pageSize).ToList();
                totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

                ViewBag.TotalRows = totalRecord;
                ViewBag.PageSize = pageSize;

                return View(allUsers);
            }

    }
}
