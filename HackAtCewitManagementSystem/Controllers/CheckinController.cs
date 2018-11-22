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
            List<Checkin> checkins = CheckinDBConnector.GetCheckins();
            List<User> nonCheckedinUsers = CheckinDBConnector.GetNonCheckedinUsers();

            UserCheckinInfo model = new UserCheckinInfo(checkins, nonCheckedinUsers);

            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        [HttpGet]
        [Route("Checkin/Add/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(string id)
        {
            CheckinDBConnector.Checkin(id, User.Identity.Name);
            return Redirect("/Checkin");
        }

    }
}
