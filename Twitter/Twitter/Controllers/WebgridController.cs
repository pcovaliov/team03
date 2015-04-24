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

            foreach (var currentUser in readingUsers.Read())
            {
                allUsers.Add(currentUser);
            }
                //using (twitterEntities dbConnection = new twitterEntities())
                //{
                //    // here MyDatabaseEntities is our DbContext // 
                //    totalRecord = dbConnection.Users.Count();
                //    totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
                //    allCustomer = dbConnection.Users.OrderBy(a => a.id_user).Skip(((page - 1) * pageSize)).Take(pageSize).ToList();
                //}

                totalRecord = allUsers.Count();
                totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

                ViewBag.TotalRows = totalRecord;
                ViewBag.PageSize = pageSize;

                return View(allUsers);
            }

    }
}
