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
    public class TestScheduleDBConnector
    {
        string dataSource;

        public TestScheduleDBConnector() {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            dataSource = "Data Source=/Users/rohan/Documents/sbu/courses/524/HackAtCewitDesktopApplication/HackAtCewitManagementSystem/Tests/test.db;";
        }

        [Fact]
        public void TestRetrieveAll()
        {
            List<Schedule> schedules = ScheduleDBConnector.GetSchedules(dataSource, "SELECT * FROM Schedule ORDER BY datetime(StartTime)");

            Assert.NotNull(schedules);
        }

        [Fact]
        public void TestRetrieveSpecific()
        {
            Schedule schedule = ScheduleDBConnector.GetSchedule(dataSource, 2);

            Assert.NotNull(schedule);
        }


        [Fact]
        public void TestInsert()
        {
            List<Schedule> schedules = ScheduleDBConnector.GetSchedules(dataSource, "SELECT * FROM Schedule ORDER BY datetime(StartTime)");

            Assert.NotNull(schedules);
            int count = schedules.Count;

            Schedule schedule = new Schedule();
            schedule.EventTitle = "Test title";
            schedule.EventDescription = "Description";
            schedule.StartTime = "2018-01-22 22:11:32";
            Assert.True(ScheduleDBConnector.Create(dataSource, schedule));


            schedules = ScheduleDBConnector.GetSchedules(dataSource, "SELECT * FROM Schedule ORDER BY datetime(StartTime)");
            Assert.NotNull(schedules);
            Assert.Equal(count + 1, schedules.Count);
        }

        [Fact]
        public void TestUpdate()
        {
            Schedule schedule = new Schedule();
            schedule.EventTitle = "Test title";
            schedule.EventDescription = "Description";
            schedule.StartTime = "2018-01-22 22:11:32";
            Assert.True(ScheduleDBConnector.Update(dataSource, schedule));
        }

        [Fact]
        public void TestDelete()
        {
            Schedule schedule = new Schedule();
            schedule.EventTitle = "Test title";
            schedule.EventDescription = "Description";
            schedule.StartTime = "2018-01-22 22:11:32";
            Assert.True(ScheduleDBConnector.Create(dataSource, schedule));

            List<Schedule> schedules = ScheduleDBConnector.GetSchedules(dataSource, "SELECT * FROM Schedule ORDER BY datetime(StartTime)");

            Assert.NotNull(schedules);

            Assert.True(FaqDBConnector.Delete(dataSource, (int)schedules[0].Id));
        }
    }
}
