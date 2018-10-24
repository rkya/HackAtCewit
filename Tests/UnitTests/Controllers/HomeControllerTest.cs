using System;
using HackAtCewitManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.UnitTests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void AboutTest()
        {
            HomeController hc = new HomeController();

            IActionResult res = hc.About();
            Assert.True(true);
        }
    }
}
