using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Models;

namespace Twitter.Repository
{
    public class UserDB
    {
        private static IList<UserModel> users = new List<UserModel>();

        public static void AddUser(UserModel userModel)
        {
            
            if (ModelState.IsValid)
            {
                using (Twitter.DAL.twitterEntities AddingUser = new Twitter.DAL.twitterEntities())
                {
                    //you should check duplicate registration here  
                    var userList = 
                        AddingUser.Users.Where
                        (currentUser => currentUser.email.Equals(userModel.email)).
                        FirstOrDefault();
                    if (userList == null)
                    {
                        AddingUser.Users.Add(userModel);
                        AddingUser.SaveChanges();
                        ModelState.Clear();
                        CurrentUser = null;
                        ViewBag.Message = "Successfully Registration Done.";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.Message = "Registration Failed, this mail is already used.";
                    }
        }
    }
}