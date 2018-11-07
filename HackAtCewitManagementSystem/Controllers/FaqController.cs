using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackAtCewitManagementSystem.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index([FromHeader]string sendJson)
        {
            ViewBag.Active = "Faq";
            var model = FaqDBConnector.GetFaqs();
            return sendJson != null && sendJson.Equals("True") ? Json(model) : (IActionResult)View(model);
        }
    }
}
