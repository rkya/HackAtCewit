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
    [Authorize]
    public class ResourcesController : Controller
    {
        [AllowAnonymous]
        [Route("Resources/{id?}")]
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
        public IActionResult Add(Resource resource)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(resource.Title);
            Console.WriteLine(resource.Link);
            Console.WriteLine(resource.Description);
            Console.WriteLine(resource.ProviderName);

            ResourceDBConnector.Create(resource);

            return Redirect("/Resources");
        }

        [HttpGet]
        [Route("Resources/Add")]
        public IActionResult Add()
        {
            return View(new Resource());
        }

        [AcceptVerbs("POST", "PUT")]
        [Route("Resources/Edit/{id}")]
        public IActionResult Edit(Resource resource, int id)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine(resource.Title);
            Console.WriteLine(resource.Link);
            Console.WriteLine(resource.Description);
            Console.WriteLine(resource.ProviderName);

            ResourceDBConnector.Update(resource);

            return Redirect("/Resources");
        }

        [HttpGet]
        [Route("Resources/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View(ResourceDBConnector.GetResource(id));
        }

        [AcceptVerbs("DELETE", "GET")]
        [Route("Resources/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            ResourceDBConnector.Delete(id);
            return Redirect("/Resources");
        }
    }
}
