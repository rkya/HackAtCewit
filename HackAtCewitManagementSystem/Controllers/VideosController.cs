using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackAtCewitManagementSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class VideosController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Video";
            var model = VideoDBConnector.GetVideos();
            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        [HttpPost]
        [Route("Videos/Add")]
        public IActionResult Add(Video video)
        {
            VideoDBConnector.Create(video);

            return Redirect("/Videos");
        }

        [HttpGet]
        [Route("Videos/Add")]
        public IActionResult Add()
        {
            return View(new Video());
        }

        [AcceptVerbs("POST", "PUT")]
        [Route("Videos/Edit/{id}")]
        public IActionResult Edit(Video video, int id)
        {
            VideoDBConnector.Update(video);

            return Redirect("/Videos");
        }

        [HttpGet]
        [Route("Videos/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View(VideoDBConnector.GetVideo(id));
        }

        [AcceptVerbs("DELETE", "GET")]
        [Route("Videos/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            VideoDBConnector.Delete(id);
            return Redirect("/Videos");
        }
    }
}
