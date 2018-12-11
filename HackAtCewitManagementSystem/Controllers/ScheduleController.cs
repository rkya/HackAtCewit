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
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Schedule";
            string sqlString = "SELECT * FROM Schedule ORDER BY datetime(StartTime)";

            var eventList = ScheduleDBConnector.GetSchedules(sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(eventList) : (IActionResult)View(eventList);
        }

        [AllowAnonymous]
        [Route("Schedule/{id}")]
        public IActionResult GetSchedule([FromHeader]string sendJson, int id)
        {
            ViewBag.Active = "Schedule";
            //string sqlString = "SELECT * FROM Schedule WHERE Id = " + id + " ORDER BY datetime(StartTime)";

            List<Schedule> eventList = new List<Schedule>();
            eventList.Add(ScheduleDBConnector.GetSchedule(id));

            return sendJson != null && sendJson.Equals("True") ? Json(eventList) : (IActionResult)View("~/Views/Schedule/Index.cshtml", eventList);
        }

        [HttpPost]
        [Route("Schedule/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Schedule schedule)
        {
            ScheduleDBConnector.Create(schedule);

            return Redirect("/Schedule");
        }

        [HttpGet]
        [Route("Schedule/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View(new Schedule());
        }

        [AcceptVerbs("POST", "PUT")]
        [Route("Schedule/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Schedule schedule, int id)
        {
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine(faq.Question);
            //Console.WriteLine(faq.Answer);

            ScheduleDBConnector.Update(schedule);

            return Redirect("/Schedule");
        }

        [HttpGet]
        [Route("Schedule/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            //Console.WriteLine(User.IsInRole("admin"));
            //Console.WriteLine(User.Identity);
            //Console.WriteLine(User.Claims);
            //Console.WriteLine(User.Identities);
            return View(ScheduleDBConnector.GetSchedule(id));
        }

        [AcceptVerbs("DELETE", "GET")]
        [Route("Schedule/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            ScheduleDBConnector.Delete(id);
            return Redirect("/Schedule");
        }
    }
}
