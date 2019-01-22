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
        /// <summary>
        /// Shows the leaderboard with checkedin users.
        /// </summary>
        /// <returns>List of users with their points.</returns>
        /// <param name="sendJson">true if the list has to be in json format.</param>
        [Route("LeaderBoard")]
        [Authorize(Roles = "admin, participant")]
        [HttpGet]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "LeaderBoard";

            var board = LeaderBoardDBConnector.GetLeaderBoard(Constants.DATA_SOURCE);

            return sendJson != null && sendJson.Equals("True") ? Json(board) : (IActionResult)View(board);
        }

        /// <summary>
        /// View to add new users on leaderboard. It returns users that are
        /// checkedin by some admin but not present on the leaderboard.
        /// </summary>
        /// <returns>View to add new users on leaderboard.</returns>
        [HttpGet]
        [Route("LeaderBoard/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add() 
        {
            return View(LeaderBoardDBConnector.GetUsersNotOnLeaderBoard(Constants.DATA_SOURCE));
        }

        /// <summary>
        /// Update the score of user on leaderboard.
        /// </summary>
        /// <returns>Redirects to the leaderboard page.</returns>
        /// <param name="leaderBoard">Leader board.</param>
        /// <param name="id">User id.</param>
        [AcceptVerbs("PUT", "POST")]
        [Route("LeaderBoard/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(LeaderBoard leaderBoard, string id)
        {
            leaderBoard.Username = id;
            LeaderBoardDBConnector.Update(Constants.DATA_SOURCE, leaderBoard);

            return Redirect("/LeaderBoard");
        }

        /// <summary>
        /// View to edit user's score on leaderboard.
        /// </summary>
        /// <returns>View of the user with his/her score.</returns>
        /// <param name="id">User id.</param>
        [HttpGet]
        [Route("LeaderBoard/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(string id)
        {
            LeaderBoard user = LeaderBoardDBConnector.GetLeaderBoardRow(Constants.DATA_SOURCE, id);
            user.Username = id;
            return View(user);
        }

        /// <summary>
        /// Delete the user from leaderboard.
        /// </summary>
        /// <returns>Redirects to the leaderboard page.</returns>
        /// <param name="id">User id.</param>
        [AcceptVerbs("DELETE", "POST")]
        [Route("LeaderBoard/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            LeaderBoardDBConnector.Delete(Constants.DATA_SOURCE, id);
            return Redirect("/LeaderBoard");
        }
    }
}
