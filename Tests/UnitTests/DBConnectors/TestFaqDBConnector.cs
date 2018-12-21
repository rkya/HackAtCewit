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
    public class TestFaqDBConnector
    {
        string dataSource;

        public TestFaqDBConnector() {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            dataSource = "Data Source=/Users/rohan/Documents/sbu/courses/524/HackAtCewitDesktopApplication/HackAtCewitManagementSystem/Tests/test.db;";
        }

        [Fact]
        public void TestRetrieveAll()
        {
            List<Faq> faqs = FaqDBConnector.GetFaqs(dataSource);

            Assert.NotNull(faqs);
        }

        [Fact]
        public void TestRetrieveSpecific()
        {
            Faq faq = FaqDBConnector.GetFaq(dataSource, 2);

            Assert.NotNull(faq);
        }


        [Fact]
        public void TestInsert()
        {
            List<Faq> faqs = FaqDBConnector.GetFaqs(dataSource);

            Assert.NotNull(faqs);
            int count = faqs.Count;

            Faq faq = new Faq();
            faq.Question = "Test Question";
            faq.Answer = "Test Answer";
            Assert.True(FaqDBConnector.Create(dataSource, faq));


            faqs = FaqDBConnector.GetFaqs(dataSource);
            Assert.NotNull(faqs);
            Assert.Equal(count + 1, faqs.Count);
        }

        [Fact]
        public void TestUpdate()
        {
            Faq faq = new Faq();
            faq.Question = "Test Question";
            faq.Answer = "Test Modified Answer";
            Assert.True(FaqDBConnector.Update(dataSource, faq));
        }

        [Fact]
        public void TestDelete()
        {
            Faq faq = new Faq();
            faq.Question = "Test Question";
            faq.Answer = "Test Answer";
            Assert.True(FaqDBConnector.Create(dataSource, faq));

            List<Faq> faqs = FaqDBConnector.GetFaqs(dataSource);

            Assert.NotNull(faqs);
            int count = faqs.Count;

            Assert.True(FaqDBConnector.Delete(dataSource, (int)faqs[0].Id));

            faqs = FaqDBConnector.GetFaqs(dataSource);

            Assert.NotNull(faqs);
            Assert.Equal(count - 1, faqs.Count);
        }
    }
}
