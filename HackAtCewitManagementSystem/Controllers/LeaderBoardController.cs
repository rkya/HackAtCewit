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
    public class LeaderBoardController : Controller
    {
        [Route("LeaderBoard")]
        [Authorize(Roles = "admin, participant")]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "LeaderBoard";
            string sqlString = "SELECT * FROM LeaderBoard ORDER BY Score DESC";
            var board = LeaderBoardDBConnector.GetLeaderBoard(sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(board) : (IActionResult)View(board);
        }

        //[AcceptVerbs("POST", "GET")]
        //[Route("LeaderBoard/Add/{id}")]
        //[Authorize(Roles = "admin")]
        //public IActionResult Add(LeaderBoard leaderBoardRow, string id)
        //{
        //    Console.WriteLine("------------------------------------------");
        //    Console.WriteLine(leaderBoardRow.Username);
        //    Console.WriteLine(leaderBoardRow.Score);
        //    Console.WriteLine(id);
        //    leaderBoardRow.Username = id;
        //    LeaderBoardDBConnector.Create(leaderBoardRow);

        //    return Redirect("/Home");
        //}

        //[HttpPost]
        //[Route("LeaderBoard/Add")]
        //[Authorize(Roles = "admin")]
        //public IActionResult Add(LeaderBoard leaderBoardRow)
        //{
        //    Console.WriteLine("============================");
        //    Console.WriteLine(leaderBoardRow.Username);
        //    Console.WriteLine(leaderBoardRow.Score);
        //    LeaderBoardDBConnector.Create(leaderBoardRow);

        //    return Redirect("/Videos");
        //}

        [HttpGet]
        [Route("LeaderBoard/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add() 
        {
            return View(LeaderBoardDBConnector.GetUsersNotOnLeaderBoard());
        }

        [AcceptVerbs("POST", "PUT")]
        [Route("LeaderBoard/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(LeaderBoard leaderBoard, string id)
        {
            leaderBoard.Username = id;
            LeaderBoardDBConnector.Update(leaderBoard);

            return Redirect("/LeaderBoard");
        }

        [HttpGet]
        [Route("LeaderBoard/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(string id)
        {
            LeaderBoard user = LeaderBoardDBConnector.GetLeaderBoardRow(id);
            Console.WriteLine(user.Username);
            user.Username = id;
            Console.WriteLine(user.Username);
            return View(user);
        }

        [HttpGet]
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
