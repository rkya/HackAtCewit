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
        /// <summary>
        /// Shows FAQs
        /// </summary>
        /// <returns>A list of questions and answers.</returns>
        /// <param name="sendJson">true if the list needs to be in the form of json.</param>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Faq";
            var model = FaqDBConnector.GetFaqs(Constants.DATA_SOURCE);
            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }

        /// <summary>
        /// Allows admin to add a new FAQ.
        /// </summary>
        /// <returns>Redirects to FAQ page.</returns>
        /// <param name="faq">FAQ to be added.</param>
        [HttpPost]
        [Route("Faq/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Faq faq) {
            FaqDBConnector.Create(Constants.DATA_SOURCE, faq);

            return Redirect("/Faq");
        }

        /// <summary>
        /// View for website.
        /// </summary>
        /// <returns>A blank view.</returns>
        [HttpGet]
        [Route("Faq/Add")]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View(new Faq());
        }

        /// <summary>
        /// Allows an admin to edit an exisiting FAQ.
        /// </summary>
        /// <returns>Redirects to the FAQ page.</returns>
        /// <param name="faq">FAQ to be edited.</param>
        /// <param name="id">FAQ id.</param>
        [AcceptVerbs("PUT", "POST")]
        [Route("Faq/Edit/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Faq faq, int id)
        {
            FaqDBConnector.Update(Constants.DATA_SOURCE, faq);

            return Redirect("/Faq");
        }

        /// <summary>
        /// View for editing the FAQ.
        /// </summary>
        /// <returns>The FAQ to be edited.</returns>
        /// <param name="id">FAQ id.</param>
        [HttpGet]
        [Route("Faq/Edit/{id}")]
        [Authorize(Roles ="admin")]
        public IActionResult Edit(int id)
        {
            return View(FaqDBConnector.GetFaq(Constants.DATA_SOURCE, id));
        }

        /// <summary>
        /// Delete the specified FAQ.
        /// </summary>
        /// <returns>Redirects to the FAQ page.</returns>
        /// <param name="id">FAQ id.</param>
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
