using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        DatabasEntities db = new DatabasEntities();

        // GET: User
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            List<Users> userList = db.Users.ToList<Users>();

            return userList;
        }
    }
}