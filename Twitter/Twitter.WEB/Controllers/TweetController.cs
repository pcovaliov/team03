using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.BL;
using Twitter.Model;
using Twitter.CRUD.CRUD;
using PagedList;
using PagedList.Mvc;
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
            int idUser = int.Parse(Session["LogedId"].ToString());    
            TweetBL NewMessage = new TweetBL();
            if (NewMessage.Message(CurrentTweet,idUser))
            {
                ViewBag.Message = "Your message  was added successfuly";
            }
            else
            {
                ViewBag.Message = "Failed to add message";
            }
                     
            return View();
        }

        public ActionResult DisplayTweets(int? page = 1)
        {
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            int idUser = int.Parse(Session["LogedId"].ToString());
            List<TweetModel> allTweets = new List<TweetModel>();
            TweetBL tweets = new TweetBL();
            allTweets = tweets.SelectTweets(idUser).OrderByDescending(currentTweet => currentTweet.CreatedOn).ToList();         
            return PartialView("_DisplayTweets", allTweets.ToPagedList(pageNumber, pageSize));
        }


        

    }
}
