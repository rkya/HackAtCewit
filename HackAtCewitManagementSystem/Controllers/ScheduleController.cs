using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        [AllowAnonymous]
        [Route("Schedule")]
        [HttpGet]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Schedule";
            string sqlString = "SELECT * FROM Schedule ORDER BY datetime(StartTime)";

            var eventList = ScheduleDBConnector.GetSchedules(Constants.DATA_SOURCE, sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(eventList) : (IActionResult)View(eventList);
        }

        [AllowAnonymous]
        [Route("Schedule/{id}")]
        [HttpGet]
        public IActionResult GetSchedule([FromHeader]string sendJson, int id)
        {
            ViewBag.Active = "Schedule";

            List<Schedule> eventList = new List<Schedule>();
            eventList.Add(ScheduleDBConnector.GetSchedule(Constants.DATA_SOURCE, id));

            return sendJson != null && sendJson.Equals("True") ? Json(eventList) : (IActionResult)View("~/Views/Schedule/Index.cshtml", eventList);
        }

        [HttpPost]
        [Route("Schedule/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Schedule schedule)
        {
            ScheduleDBConnector.Create(Constants.DATA_SOURCE, schedule);

            return Redirect("/Schedule");
        }

        [HttpGet]
        [Route("Schedule/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View(new Schedule());
        }

        [AcceptVerbs("PUT", "POST")]
        [Route("Schedule/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Schedule schedule, int id)
        {
            ScheduleDBConnector.Update(Constants.DATA_SOURCE, schedule);

            return Redirect("/Schedule");
        }

        [HttpGet]
        [Route("Schedule/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            return View(ScheduleDBConnector.GetSchedule(Constants.DATA_SOURCE, id));
        }

        [AcceptVerbs("DELETE", "POST")]
        [Route("Schedule/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            ScheduleDBConnector.Delete(Constants.DATA_SOURCE, id);
            return Redirect("/Schedule");
        }
    }
}
