using System;
using System.IO;
using HackAtCewitManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Xunit;

namespace Tests.UnitTests.Controllers
{
    public class ResourcesControllerTest
    {

        [Fact]
        public void IndexTest()
        {
            ResourcesController hc = new ResourcesController();
            Action testCode = () => { hc.Index("True", 3); };

            var ex = Record.Exception(testCode);
            Assert.NotNull(ex);
            Assert.IsType<FileNotFoundException>(ex);
        }
    }
}
