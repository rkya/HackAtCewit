using System;
using HackAtCewitManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Xunit;

namespace Tests.UnitTests.Controllers
{
    public class HomeControllerTest
    {

        [Fact]
        public void IndexTest()
        {
            HomeController hc = new HomeController();
            ViewResult result = hc.Index() as ViewResult;
            Assert.NotNull(result);
            Assert.True(result.ViewName == null);
        }

        [Fact]
        public void AboutTest()
        {
            HomeController hc = new HomeController();
            ViewResult result = hc.About() as ViewResult;
            Assert.NotNull(result);
            Assert.True(result.ViewName == null);
        }

        [Fact]
        public void ContactTest()
        {
            HomeController hc = new HomeController();
            ViewResult result = hc.Contact() as ViewResult;
            Assert.NotNull(result);
            Assert.True(result.ViewName == null);
        }

    }
}
