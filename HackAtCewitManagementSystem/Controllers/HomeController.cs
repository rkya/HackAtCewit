using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackAtCewitManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Active = "Home";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";
            ViewBag.Active = "About";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewBag.Active = "Contact";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Faq()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";
            //ViewBag.Active = "Faq";
            //return View();
            var model = new List<Faq>();

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * from Faq", conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var faq = new Faq
                    {
                        Question = (string)rdr["Question"],
                        Answer = (string)rdr["Answer"]
                    };

                    model.Add(faq);
                }
            }
            ViewBag.Active = "Faq";
            return View(model);
        }

        public IActionResult Schedule([FromHeader]string sendJson)
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";
            //ViewBag.Active = "Schedule";
            var model = new List<Schedule>();

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * from Schedule", conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var schedule = new Schedule();
                    schedule.StartTime = (string)rdr["StartTime"];
                    schedule.EndTime = (string)rdr["EndTime"];
                    schedule.EventDescription = (string)rdr["EventDescription"];
                    schedule.Room = (string)rdr["Room"];

                    model.Add(schedule);
                }
            }
            ViewBag.Active = "Schedule";

            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        public IActionResult Video()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";
            ViewBag.Active = "Video";
            return View();
        }

        public IActionResult Resources()
        {
            ViewData["Message"] = "Hack@CEWIT is the Center of Excellence in Wireless and Information Technology (CEWIT)'s interdisciplinary IoT-focused hackathon bringing students together for a two-day technical challenge over President's Day Weekend.";
            ViewBag.Active = "Resources";
            return View();
        }
    }
}
