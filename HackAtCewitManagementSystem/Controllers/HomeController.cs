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
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.Active = "Home";
            return View();
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";
            ViewBag.Active = "About";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewBag.Active = "Contact";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
