using System;
using System.IO;
using HackAtCewitManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Xunit;

namespace Tests.UnitTests.Controllers
{
    public class LeaderBoardControllerTest
    {

        [Fact]
        public void IndexTest()
        {
            LeaderBoardController hc = new LeaderBoardController();
            Action testCode = () => { hc.Index("True"); };

            var ex = Record.Exception(testCode);
            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }
    }
}
