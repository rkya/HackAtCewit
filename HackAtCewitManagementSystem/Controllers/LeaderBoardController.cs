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

            var board = LeaderBoardDBConnector.GetLeaderBoard(Constants.DATA_SOURCE);

            return sendJson != null && sendJson.Equals("True") ? Json(board) : (IActionResult)View(board);
        }

        [HttpGet]
        [Route("LeaderBoard/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add() 
        {
            return View(LeaderBoardDBConnector.GetUsersNotOnLeaderBoard(Constants.DATA_SOURCE));
        }

        [HttpPut]
        [Route("LeaderBoard/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(LeaderBoard leaderBoard, string id)
        {
            leaderBoard.Username = id;
            LeaderBoardDBConnector.Update(Constants.DATA_SOURCE, leaderBoard);

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
            LeaderBoardDBConnector.Delete(Constants.DATA_SOURCE, id);
            return Redirect("/LeaderBoard");
        }
    }
}
