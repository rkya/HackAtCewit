using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackAtCewitManagementSystem.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        [AllowAnonymous]
        [Route("Schedule/{id?}")]
        public IActionResult Index([FromHeader]string sendJson, int? id)
        {
            ViewBag.Active = "Schedule";
            string sqlString = "SELECT * FROM Schedule ORDER BY datetime(StartTime)";
            if (id.HasValue)
            {
                sqlString += " WHERE Id = " + id.Value;
                var model = ScheduleDBConnector.GetSchedules(sqlString);
                var singleEvent = model.Count > 0 ? model.First() : new Schedule(-1);
                Console.WriteLine(singleEvent.Id);
                return sendJson != null && sendJson.Equals("True") ? Json(singleEvent) : (IActionResult)View(singleEvent);
            }
            var eventList = ScheduleDBConnector.GetSchedules(sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(eventList) : (IActionResult)View(eventList);
        }
    }
}
