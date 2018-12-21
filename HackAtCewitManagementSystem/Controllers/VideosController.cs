using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackAtCewitManagementSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class VideosController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Video";
            var model = VideoDBConnector.GetVideos(Constants.DATA_SOURCE);
            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        [HttpPost]
        [Route("Videos/Add")]
        public IActionResult Add(Video video)
        {
            VideoDBConnector.Create(Constants.DATA_SOURCE, video);

            return Redirect("/Videos");
        }

        [HttpGet]
        [Route("Videos/Add")]
        public IActionResult Add()
        {
            return View(new Video());
        }

        [AcceptVerbs("PUT", "POST")]
        [Route("Videos/Edit/{id}")]
        public IActionResult Edit(Video video, int id)
        {
            VideoDBConnector.Update(Constants.DATA_SOURCE, video);

            return Redirect("/Videos");
        }

        [HttpGet]
        [Route("Videos/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View(VideoDBConnector.GetVideo(Constants.DATA_SOURCE, id));
        }

        [AcceptVerbs("DELETE", "POST")]
        [Route("Videos/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            VideoDBConnector.Delete(Constants.DATA_SOURCE, id);
            return Redirect("/Videos");
        }
    }
}
