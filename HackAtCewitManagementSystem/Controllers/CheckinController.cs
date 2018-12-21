using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackAtCewitManagementSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class CheckinController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Checkin";
            List<Checkin> checkins = CheckinDBConnector.GetCheckins(Constants.DATA_SOURCE);
            List<User> nonCheckedinUsers = CheckinDBConnector.GetNonCheckedinUsers(Constants.DATA_SOURCE);

            UserCheckinInfo model = new UserCheckinInfo(checkins, nonCheckedinUsers);

            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        //[HttpPost]
        //[Route("Checkin/Add/{id}")]
        //[Authorize(Roles = "admin")]
        //public IActionResult Add(string id, [FromBody]string username)
        //{
        //    CheckinDBConnector.Checkin(id, User.Identity.Name);
        //    return Redirect("/Checkin");
        //}

        //[HttpGet]
        //[Route("Checkin/Add")]
        //[Authorize(Roles = "admin")]
        //public IActionResult AddGet(string id, [FromBody]string username)
        //{
        //    Console.WriteLine("Add get method hit...!!");
        //    return Redirect("/Checkin");
        //}

        //[HttpPost]
        //[Route("Checkin/Add")]
        //[Authorize(Roles = "admin")]
        //public IActionResult AddPost(UserCheckinInfo info)
        //{
        //    Console.WriteLine("Add post method hit...!!");
        //    Console.WriteLine(info.usercheckin);
        //    //Console.WriteLine(info.nonCheckedinUsers.Count);
        //    return Redirect("/Checkin");
        //}

        [HttpPost]
        [Route("Checkin")]
        [Authorize(Roles = "admin")]
        public IActionResult CheckinUser(User user)
        {
            CheckinDBConnector.Checkin(Constants.DATA_SOURCE, user.Username, User.Identity.Name);
            return Redirect("/Checkin");
        }

    }
}
