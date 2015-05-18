using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Services;
using Twitter.Models;
using PagedList;
using PagedList.Mvc;
using log4net;
using System.Web.Security;

namespace Twitter.WEB.Controllers
{
    
    public class TweetController : Controller
    {
        #region Private
        public ITweetService TweetService { get; set; }
        #endregion

        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(TweetService));
        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Message(TweetModel CurrentTweet)
        {
            int idUser = int.Parse(Session["LogedId"].ToString());
            if (TweetService.Message(CurrentTweet, idUser))
            {
                log.Info("Message added successfuly "+CurrentTweet.IdTweet +" - IDUser - "+idUser );
                ViewBag.Message = "Your message  was added successfuly";
            }
            else
            {
                ViewBag.Message = "Failed to add message";
            }

            return View();
        }
        [Authorize]
        public ActionResult DisplayTweets(int? page = 1)
        {
            int pageSize = 25;
            int pageNumber = (page ?? 1);
            int idUser = int.Parse(Session["LogedId"].ToString());
            List<TweetModel> allTweets = new List<TweetModel>();
            allTweets = TweetService.SelectTweets(idUser).OrderByDescending(currentTweet => currentTweet.CreatedOn).ToList();
            log.Info("Displayed tweets Succesfuly");
            return PartialView("_DisplayTweets", allTweets.ToPagedList(pageNumber, pageSize));
        }
        [Authorize]
        public ActionResult Delete(int item)
        {
            if (TweetService.DeleteTweet(item))
            {
                log.Info("Deleted tweets succesfuly, id="+item);
                return RedirectToAction("Message");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int item)
        {
            var currentTweet = TweetService.GetTweet(item);
            if (currentTweet != null)
            {
                return View(currentTweet);
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(TweetModel currentTweet)
        {   
            int idCurrentUser = int.Parse(Session["LogedId"].ToString());
            currentTweet.IdUser = idCurrentUser;
            if (TweetService.EditTweet(currentTweet,idCurrentUser))
            {
                log.Info("Tweet edited succesfuly " + currentTweet.IdTweet + " - IDUser - " + idCurrentUser);
                return RedirectToAction("Message");
            }
            else
            {
                return View(currentTweet);
            }
        }     
    }
}
