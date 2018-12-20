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
    public class LeaderBoardController : Controller
    {
        [Route("LeaderBoard")]
        [Authorize(Roles = "admin, participant")]
        [HttpGet]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "LeaderBoard";
            string sqlString = "SELECT * FROM LeaderBoard ORDER BY Score DESC";
            var board = LeaderBoardDBConnector.GetLeaderBoard(sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(board) : (IActionResult)View(board);
        }

        [HttpGet]
        [Route("LeaderBoard/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add() 
        {
            return View(LeaderBoardDBConnector.GetUsersNotOnLeaderBoard());
        }

        [HttpPut]
        [Route("LeaderBoard/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(LeaderBoard leaderBoard, string id)
        {
            leaderBoard.Username = id;
            LeaderBoardDBConnector.Update(leaderBoard);

            return Redirect("/LeaderBoard");
        }

        //[HttpPut]
        //[Route("LeaderBoard/Edit/{id}")]
        //[Authorize(Roles = "admin")]
        //public IActionResult Edit(string id)
        //{
        //    LeaderBoard user = LeaderBoardDBConnector.GetLeaderBoardRow(id);
        //    Console.WriteLine(user.Username);
        //    user.Username = id;
        //    Console.WriteLine(user.Username);
        //    return View(user);
        //}

        [HttpDelete]
        [Route("LeaderBoard/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            Console.WriteLine(id);
            LeaderBoardDBConnector.Delete(id);
            return Redirect("/LeaderBoard");
        }
    }
}
