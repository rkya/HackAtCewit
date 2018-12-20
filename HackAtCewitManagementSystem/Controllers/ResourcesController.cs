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
    [Authorize]
    public class ResourcesController : Controller
    {
        [AllowAnonymous]
        [Route("Resources/{id?}")]
        [HttpGet]
        public IActionResult Index([FromHeader]string sendJson, int? id)
        {
            ViewBag.Active = "Resources";
            string sqlString = "SELECT * FROM Resource";
            if (id.HasValue)
            {
                sqlString += " WHERE Id = " + id.Value;
                var model = ResourceDBConnector.GetResources(sqlString);
                var singleEvent = model.Count > 0 ? model.First() : new Resource();
                Console.WriteLine(singleEvent.Id);
                return sendJson != null && sendJson.Equals("True") ? Json(singleEvent) : (IActionResult)View(singleEvent);
            }
            var eventList = ResourceDBConnector.GetResources(sqlString);

            return sendJson != null && sendJson.Equals("True") ? Json(eventList) : (IActionResult)View(eventList);
        }

        [HttpPost]
        [Route("Resources/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Resource resource)
        {
            ResourceDBConnector.Create(resource);

            return Redirect("/Resources");
        }

        [HttpGet]
        [Route("Resources/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View(new Resource());
        }

        [HttpPut]
        [Route("Resources/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Resource resource, int id)
        {
            ResourceDBConnector.Update(resource);

            return Redirect("/Resources");
        }

        [HttpGet]
        [Route("Resources/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            return View(ResourceDBConnector.GetResource(id));
        }

        [HttpDelete]
        [Route("Resources/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            ResourceDBConnector.Delete(id);
            return Redirect("/Resources");
        }
    }
}
