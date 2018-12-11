using System;
using System.IO;
using HackAtCewitManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Xunit;

namespace Tests.UnitTests.Controllers
{
    public class ScheduleControllerTest
    {

        [Fact]
        public void IndexTest()
        {
            ScheduleController hc = new ScheduleController();
            Action testCode = () => { hc.Index("True"); };

            var ex = Record.Exception(testCode);
            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }
    }
}
