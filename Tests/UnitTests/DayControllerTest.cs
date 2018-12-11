using System;
using System.IO;
using HackAtCewitManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Xunit;

namespace Tests.UnitTests.Controllers
{
    public class DayControllerTest
    {

        [Fact]
        public void IndexTest()
        {
            DayController hc = new DayController();
            Action testCode = () => { hc.Index(2018, 11, 15, "True"); };

            var ex = Record.Exception(testCode);
            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }
    }
}
