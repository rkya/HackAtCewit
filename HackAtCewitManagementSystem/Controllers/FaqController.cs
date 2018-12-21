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
            var model = FaqDBConnector.GetFaqs(Constants.DATA_SOURCE);
            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        [HttpPost]
        [Route("Faq/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Faq faq) {
            FaqDBConnector.Create(Constants.DATA_SOURCE, faq);

            return Redirect("/Faq");
        }

        [HttpGet]
        [Route("Faq/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View(new Faq());
        }

        [AcceptVerbs("PUT", "POST")]
        [Route("Faq/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Faq faq, int id)
        {
            FaqDBConnector.Update(Constants.DATA_SOURCE, faq);

            return Redirect("/Faq");
        }

        [HttpGet]
        [Route("Faq/Edit/{id}")]
        [Authorize(Roles ="admin")]
        public IActionResult Edit(int id)
        {
            return View(FaqDBConnector.GetFaq(Constants.DATA_SOURCE, id));
        }

        [AcceptVerbs("DELETE", "POST")]
        [Route("Faq/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            FaqDBConnector.Delete(Constants.DATA_SOURCE, id);
            return Redirect("/Faq");
        }
    }
}
