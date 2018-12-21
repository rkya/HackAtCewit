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
    public class TestCheckinDBConnector
    {
        string dataSource;

        public TestCheckinDBConnector() {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            dataSource = "Data Source=/Users/rohan/Documents/sbu/courses/524/HackAtCewitDesktopApplication/HackAtCewitManagementSystem/Tests/test.db;";
        }

        [Fact]
        public void TestCheckedinUsers()
        {
            List<Checkin> checkins = CheckinDBConnector.GetCheckins(dataSource);

            Assert.NotNull(checkins);
            Assert.NotNull(checkins[0].participant);
            Assert.NotNull(checkins[0].admin);
            Assert.Equal("newUser@test.com", checkins[0].participant.Username);
            Assert.Equal("admin@cewit.com", checkins[0].admin.Username);
        }

        [Fact]
        public void TestNonCheckedinUsers()
        {
            List<User> users = CheckinDBConnector.GetNonCheckedinUsers(dataSource);

            Assert.NotNull(users);
            Assert.Equal(4, users.Count);
            Assert.Equal("rk@gmail.com", users[0].Username);
            Assert.Equal("test@cewit.com", users[1].Username);
            Assert.Equal("user2@cewit.com", users[2].Username);
            Assert.Equal("admin@cewit.com", users[3].Username);
        }


        [Fact]
        public void TestUserCheckin()
        {
            Assert.True(CheckinDBConnector.Checkin(dataSource, "newUser@test.com", "admin@cewit.com"));




            //Code to cleanup the tables so that the test case would run successfully the next time.
            string checkinDelete = "DELETE FROM Checkin WHERE user = 'newUser@test.com' AND admin = 'admin@cewit.com'";
            string userRoleDelete = "DELETE FROM AspNetUserRoles WHERE UserId = 7 AND RoleId = 2";

            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();
                SqliteCommand deleteSQL = new SqliteCommand(checkinDelete, conn);

                try
                {
                    deleteSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                deleteSQL = new SqliteCommand(userRoleDelete, conn);

                try
                {
                    deleteSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
