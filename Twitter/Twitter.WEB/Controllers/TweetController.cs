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

            TweetBL NewMessage = new TweetBL();
            if (NewMessage.Message(CurrentTweet))
            {
                ViewBag.Message = "Your message  was added successfuly";
                //return RedirectToAction("DisplayTweets");
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
            //int totalPage = 0;
            //int totalRecord = 0;

            List<TweetModel> allTweets = new List<TweetModel>();
            TweetBL tweets = new TweetBL();

            //totalRecord = tweets.SelectTweets().Count();
            //allTweets = tweets.SelectTweets().OrderByDescending(a => a.CreatedOn).Skip(((page - 1) * pageSize)).Take(pageSize).ToList();
            //totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            //ViewBag.TotalRows = totalRecord;
            //ViewBag.PageSize = pageSize;
            //totalRecord = tweets.SelectTweets().Count();
            allTweets = tweets.SelectTweets().OrderByDescending(currentTweet => currentTweet.CreatedOn).ToList();

           
            return PartialView("_DisplayTweets", allTweets.ToPagedList(pageNumber, pageSize));
        }


        

    }
}
