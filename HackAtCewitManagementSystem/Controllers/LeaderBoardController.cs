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
    public class LeaderBoardController : Controller
    {
        [AllowAnonymous]
        [Route("LeaderBoard")]
        public IActionResult Index([FromHeader]string sendJson)
        {
            //ViewBag.Active = "Schedule";
            string sqlString = "SELECT * FROM LeaderBoard ORDER BY Score DESC";
            var board = LeaderBoardDBConnector.GetLeaderBoard(sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(board) : (IActionResult)View(board);
        }
    }
}
