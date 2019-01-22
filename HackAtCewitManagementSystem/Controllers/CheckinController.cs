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
        /// <summary>
        /// Used to checkin users.
        /// </summary>
        /// <returns>The list of checkedin and non-checkedin users.</returns>
        /// <param name="sendJson">true if returns object has to be in json format</param>
        [HttpGet]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Checkin";
            List<Checkin> checkins = CheckinDBConnector.GetCheckins(Constants.DATA_SOURCE);
            List<User> nonCheckedinUsers = CheckinDBConnector.GetNonCheckedinUsers(Constants.DATA_SOURCE);

            UserCheckinInfo model = new UserCheckinInfo(checkins, nonCheckedinUsers);

            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        /// <summary>
        /// Used by admins to checkin a specific user.
        /// </summary>
        /// <returns>Redirects to the checkin page.</returns>
        /// <param name="user">User to be checkedin.</param>
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
