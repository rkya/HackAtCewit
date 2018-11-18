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
    [Authorize]
    public class FaqController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Faq";
            var model = FaqDBConnector.GetFaqs();
            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        public IActionResult UserTest([FromHeader]string sendJson)
        {
            ViewBag.Active = "Faq";
            var model = FaqDBConnector.GetFaqs();
            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        [HttpPost]
        [Route("Faq/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Faq faq) {
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine(faq.Question);
            //Console.WriteLine(faq.Answer);

            FaqDBConnector.Create(faq);

            return Redirect("/Faq");
        }

        [HttpGet]
        [Route("Faq/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View(new Faq());
        }

        [AcceptVerbs("POST", "PUT")]
        [Route("Faq/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Faq faq, int id)
        {
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine(faq.Question);
            //Console.WriteLine(faq.Answer);

            FaqDBConnector.Update(faq);

            return Redirect("/Faq");
        }

        [HttpGet]
        [Route("Faq/Edit/{id}")]
        [Authorize(Roles ="admin")]
        public IActionResult Edit(int id)
        {
            //Console.WriteLine(User.IsInRole("admin"));
            //Console.WriteLine(User.Identity);
            //Console.WriteLine(User.Claims);
            //Console.WriteLine(User.Identities);
            return View(FaqDBConnector.GetFaq(id));
        }

        [AcceptVerbs("DELETE", "GET")]
        [Route("Faq/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            FaqDBConnector.Delete(id);
            return Redirect("/Faq");
        }
    }
}
