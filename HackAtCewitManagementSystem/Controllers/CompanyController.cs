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
    public class CompanyController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("Company")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Company")]
        [Authorize(Roles = "admin")]
        public IActionResult CompanyPost(Customer customer) {
            Console.WriteLine(customer.CompanyName);
            Console.WriteLine(customer.ContactName);
            Console.WriteLine(customer.EmployeeCount);
            Console.WriteLine("--------------------");
            return View("~/Views/Company/Index.cshtml");
        }
    }
}
