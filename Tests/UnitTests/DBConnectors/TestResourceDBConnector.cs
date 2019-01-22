using System;
using System.Collections.Generic;
using System.IO;
using HackAtCewitManagementSystem.Controllers;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Data.Sqlite;
using Xunit;

namespace Tests.UnitTests.DBConnectors
{
    public class TestResourceDBConnector
    {
        string dataSource;

        public TestResourceDBConnector() {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            dataSource = "Data Source=/Users/rohan/Documents/sbu/courses/524/HackAtCewitDesktopApplication/HackAtCewitManagementSystem/Tests/test.db;";
        }

        [Fact]
        public void TestRetrieveAll()
        {
            List<Resource> resources = ResourceDBConnector.GetResources(dataSource, "SELECT * FROM Resource");

            Assert.NotNull(resources);
        }

        [Fact]
        public void TestRetrieveSpecific()
        {
            Resource resource = ResourceDBConnector.GetResource(dataSource, 2);

            Assert.NotNull(resource);
        }


        [Fact]
        public void TestInsert()
        {
            List<Resource> resources = ResourceDBConnector.GetResources(dataSource, "SELECT * FROM Resource");

            Assert.NotNull(resources);
            int count = resources.Count;

            Resource resource = new Resource();
            resource.Description = "Test";
            resource.Link = "some link";
            resource.Title = "Test Resource";
            resource.ProviderName = "Unit Test";
            Assert.True(ResourceDBConnector.Create(dataSource, resource));


            resources = ResourceDBConnector.GetResources(dataSource, "SELECT * FROM Resource");
            Assert.NotNull(resources);
            Assert.Equal(count + 1, resources.Count);
        }

        [Fact]
        public void TestUpdate()
        {
            Resource resource = new Resource();
            resource.Description = "Test";
            resource.Link = "some link";
            resource.Title = "Test Resource";
            resource.ProviderName = "Unit Test";
            Assert.True(ResourceDBConnector.Update(dataSource, resource));
        }

        [Fact]
        public void TestDelete()
        {
            Resource resource = new Resource();
            resource.Description = "Test";
            resource.Link = "some link";
            resource.Title = "Test Resource";
            resource.ProviderName = "Unit Test";
            Assert.True(ResourceDBConnector.Create(dataSource, resource));

            List<Resource> resources = ResourceDBConnector.GetResources(dataSource, "SELECT * FROM Resource");

            Assert.NotNull(resources);
            int count = resources.Count;

            Assert.True(ResourceDBConnector.Delete(dataSource, (int)resources[0].Id));

            resources = ResourceDBConnector.GetResources(dataSource, "SELECT * FROM Resource");

            Assert.NotNull(resources);
            Assert.Equal(count - 1, resources.Count);
        }
    }
}
