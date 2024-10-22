﻿using System;
using System.Collections.Generic;
using HackAtCewitManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Utils
{
    public static class CheckinDBConnector
    {
        public static List<Checkin> GetCheckins(string dataSource) {
            List<Checkin> checkins = new List<Checkin>();

            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT users.Id as UserId, users.UserName as Username, adminUser.Id as AdminId, adminUser.UserName as AdminUsername, ckn.Timestamp as Timestamp FROM AspNetUsers users, Checkin ckn, AspNetUsers adminUser WHERE users.UserName = ckn.Username AND adminUser.UserName = ckn.CheckedinBy", conn);

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
            }

            return checkins;
        }

        public static List<User> GetNonCheckedinUsers(string dataSource)
        {
            List<User> users = new List<User>();

            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT users.UserName as Username, users.Id as Id FROM AspNetUsers users WHERE users.UserName not in (SELECT DISTINCT Username from Checkin)", conn);

                SqliteDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    User user = new User
                    {
                        Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"],
                        Id = rdr["Id"] == DBNull.Value ? "" : (string)rdr["Id"]
                    };

                    users.Add(user);
                }
            }

            return users;
        }

        public static bool Checkin(string dataSource, string user, string admin) {
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                bool returnValue = true;

                conn.Open();
                SqliteCommand insertSQL = new SqliteCommand("INSERT INTO Checkin(Username, CheckedinBy, Timestamp) VALUES ('" + user + "','" + admin + "', datetime('now', 'localtime'))", conn);

                try
                {
                    insertSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    returnValue = false;
                }


                string participantRole = "INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ((SELECT Id FROM AspNetUsers WHERE UserName = '" + user + "'), (SELECT Id FROM AspNetRoles WHERE name = 'participant'))";

                insertSQL = new SqliteCommand(participantRole, conn);

                try
                {
                    insertSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

                return returnValue;
            }
        }
    }
}
