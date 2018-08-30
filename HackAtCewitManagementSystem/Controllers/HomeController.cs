using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackAtCewitManagementSystem.Models;

namespace HackAtCewitManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Faq()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";

            return View();
        }

        public IActionResult Schedule()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";

            return View();
        }

        public IActionResult Video()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";

            return View();
        }

        public IActionResult Resources()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";

            return View();
        }
    }
}
