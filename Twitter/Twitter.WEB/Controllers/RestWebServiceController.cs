using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twitter.Models;
using Twitter.Services;

namespace Twitter.WEB.Controllers
{
    public class RestWebServiceController : ApiController
    {
        public IUserService UserService {get; set;}

        public System.Web.Http.Results.JsonResult<System.Collections.Generic.List<UserModel>> Get() 
        { 
            var allUsers = UserService.SelectUsers();
            return Json(allUsers);
        }
    }
}
