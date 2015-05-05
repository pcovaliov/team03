using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.DAL;
using Twitter.Models;
using Twitter.CRUD;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Twitter.Controllers
{

    public class TweetController : Controller
    {
             
        //public ActionResult Message()
        //{
        //    return View();
        //}

        //[HttpPost]       
        //public ActionResult Message(TweetModel CurrentTweet)
        //{

        //        TweetCRUD AddingTweet = new TweetCRUD();
        //        if (AddingTweet.AddTweet(CurrentTweet))
        //        {
        //            ViewBag.Message = "Your message  was added successfuly";
        //            //return RedirectToAction("Message");
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Failed to add message";
        //        }
        //    return View(CurrentTweet);
        //}
    }
}
