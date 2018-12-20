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

namespace Tests.UnitTests.Controllers
{
    public class CheckinControllerTest
    {

        [Fact]
        public void IndexTest()
        {
            CheckinController hc = new CheckinController();
            Action testCode = () => { hc.Index("True"); };
            //System.Exception : You need to call SQLitePCL.raw.SetProvider().If you are using a bundle package, this is done by calling 
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            List<Checkin> checkins = GetCheckins();

            foreach (Checkin checkin in checkins) {
                Console.WriteLine(checkin.participant.Username);
            }

            //var ex = Record.Exception(testCode);
            //Assert.NotNull(ex);
            //Assert.IsType<FileNotFoundException>(ex);
        }

        public static List<Checkin> GetCheckins()
        {
            List<Checkin> checkins = new List<Checkin>();

            using (SqliteConnection conn = new SqliteConnection("Data Source=/Users/rohan/Documents/sbu/courses/524/HackAtCewitDesktopApplication/HackAtCewitManagementSystem/Tests/test.db;"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT users.Id as UserId, users.UserName as Username, adminUser.Id as AdminId, adminUser.UserName as AdminUsername, ckn.Timestamp as Timestamp FROM AspNetUsers users, Checkin ckn, AspNetUsers adminUser WHERE users.UserName = ckn.Username AND adminUser.UserName = ckn.CheckedinBy", conn);

                Console.WriteLine(cmd);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var checkin = new Checkin
                    {
                        timestamp = rdr["Timestamp"] == DBNull.Value ? "" : (string)rdr["Timestamp"],
                        participant = new User
                        {
                            Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"],
                            Id = rdr["UserId"] == DBNull.Value ? "" : (string)rdr["UserId"]
                        },
                        admin = new User
                        {
                            Username = rdr["AdminUsername"] == DBNull.Value ? "" : (string)rdr["AdminUsername"],
                            Id = rdr["AdminId"] == DBNull.Value ? "" : (string)rdr["AdminId"]

                        }
                    };

                    checkins.Add(checkin);
                }

                conn.Close();
            }

            return checkins;
        }

    }
}
