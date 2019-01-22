using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackAtCewitManagementSystem.Models;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Authorization;

namespace HackAtCewitManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Static view of homepage.
        /// </summary>
        /// <returns>The view of homepage.</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Active = "Home";
            return View();
        }

        /// <summary>
        /// Static view of about us page.
        /// </summary>
        /// <returns>The view of about us page.</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";
            ViewBag.Active = "About";
            return View();
        }

        /// <summary>
        /// Static view of contact page.
        /// </summary>
        /// <returns>The view of contact page.</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "CEWIT contact page.";
            ViewBag.Active = "Contact";
            return View();
        }

        /// <summary>
        /// Error page.
        /// </summary>
        /// <returns>The view of error page.</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
