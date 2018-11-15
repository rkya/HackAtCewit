using System;
using HackAtCewitManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.UnitTests
{
    public class SampleTest
    {

        [Fact]
        public void test() {
            Assert.True(true);
        }

        [Fact]
        public void testHomeController() {
            HomeController hc = new HomeController();

            IActionResult res = hc.About();
            Assert.True(true);
        }


    }
}
