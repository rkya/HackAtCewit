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
    public class DayController : Controller
    {
        /// <summary>
        /// Gets schedule of events on a day.
        /// </summary>
        /// <returns>All the events on a particular day.</returns>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="sendJson">true if object to be returned has to be in json format.</param>
        [HttpGet]
        [AllowAnonymous]
        [Route("Day/{year}/{month}/{day}")]
        public IActionResult Index(int year, int month, int day, [FromHeader]string sendJson)
        {
            if(month < 1 || month > 12 || day < 1 || day > 31) {
                return sendJson != null && sendJson.Equals("True") ? Json(new List<Schedule>()) : (IActionResult)View("Views/Schedule/Index.cshtml", null);
            }

            string sqlString = "SELECT * FROM Schedule WHERE Date(StartTime) = \"" + year + "-" + (month < 10 ? "0" : "") + month + "-" + (day < 10 ? "0" : "") + day + "\"";

            var model = ScheduleDBConnector.GetSchedules(Constants.DATA_SOURCE, sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View("Views/Schedule/Index.cshtml", model);
        }
    }
}
