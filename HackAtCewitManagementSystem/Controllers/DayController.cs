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
    public class DayController : Controller
    {
        [AllowAnonymous]
        [Route("Day/{year}/{month}/{day}")]
        public IActionResult Index(int year, int month, int day, [FromHeader]string sendJson)
        {
            if(month < 1 || month > 12 || day < 1 || day > 31) {
                return sendJson != null && sendJson.Equals("True") ? Json(new List<Schedule>()) : (IActionResult)View();
            }

            string sqlString = "SELECT * FROM Schedule WHERE Date(StartTime) = \"" + year + "-" + (month < 10 ? "0" : "") + month + "-" + (day < 10 ? "0" : "") + day + "\"";

            Console.WriteLine("String----->" + sqlString);
            var model = ScheduleDBConnector.GetSchedules(sqlString);

            ViewBag.Active = "Schedule";

            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }
    }
}
