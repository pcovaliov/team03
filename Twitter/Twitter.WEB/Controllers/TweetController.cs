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
    public class TweetController : Controller
    {
        //
        // GET: /Tweet/

        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Message(TweetModel CurrentTweet)
        {

            UserBL NewMessage = new UserBL();
            if (NewMessage.Message(CurrentTweet))
            {
                ViewBag.Message = "Your message  was added successfuly";
                //return RedirectToAction("Message");
            }
            else
            {
                ViewBag.Message = "Failed to add message";
            }
            return View();
        }

    }
}
