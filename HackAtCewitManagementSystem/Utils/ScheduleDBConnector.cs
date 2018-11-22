using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAtCewitManagementSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Utils
{
    public static class ScheduleDBConnector
    {
        public static List<Schedule> GetSchedules(string sqlQuery)
        {
            List<Schedule> schedules = new List<Schedule>();

            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand(sqlQuery, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    try
                    {
                        var schedule = new Schedule
                        {
                            StartTime = rdr["StartTime"] == DBNull.Value ? "" : (string)rdr["StartTime"],
                            EndTime = rdr["EndTime"] == DBNull.Value ? "" : (string)rdr["EndTime"],
                            EventDescription = rdr["EventDescription"] == DBNull.Value ? "" : (string)rdr["EventDescription"],
                            Room = rdr["Room"] == DBNull.Value ? "" : (string)rdr["Room"],
                            Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"],
                            EventTitle = rdr["EventTitle"] == DBNull.Value ? "" : (string)rdr["EventTitle"],
                            Presenter = rdr["Presenter"] == DBNull.Value ? "" : (string)rdr["Presenter"]
                        };
                        schedules.Add(schedule);
                    }
                    catch(Exception e) {
                        Console.WriteLine(e.ToString());
                    }

                }
            }

            return schedules;
        }

        public static Schedule GetSchedule(int id)
        {
            Schedule schedule = null;

            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * FROM Schedule WHERE Id = " + id, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    schedule = new Schedule
                    {
                        StartTime = rdr["StartTime"] == DBNull.Value ? "" : (string)rdr["StartTime"],
                        EndTime = rdr["EndTime"] == DBNull.Value ? "" : (string)rdr["EndTime"],
                        EventDescription = rdr["EventDescription"] == DBNull.Value ? "" : (string)rdr["EventDescription"],
                        Room = rdr["Room"] == DBNull.Value ? "" : (string)rdr["Room"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"],
                        EventTitle = rdr["EventTitle"] == DBNull.Value ? "" : (string)rdr["EventTitle"],
                        Presenter = rdr["Presenter"] == DBNull.Value ? "" : (string)rdr["Presenter"]
                    };

                }
            }

            return schedule ?? new Schedule();
        }

        public static bool Create(Schedule schedule)
        {
            return InsertOrUpdate(schedule);
        }

        public static bool Update(Schedule schedule)
        {
            return InsertOrUpdate(schedule);
        }

        private static bool InsertOrUpdate(Schedule schedule)
        {
            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {
                conn.Open();
                SqliteCommand insertSQL = new SqliteCommand("INSERT OR REPLACE INTO Schedule(Id, StartTime, EndTime, EventDescription, Room, EventTitle, Presenter) VALUES ((SELECT Id FROM Schedule WHERE Id = " + schedule.Id + "), '" + schedule.StartTime + "', '" + schedule.EndTime + "', '" + schedule.EventDescription + "', '" + schedule.Room + "', '" + schedule.EventTitle + "', '" + schedule.Presenter + "')", conn);
                //insertSQL.Parameters.Add(faq.Id);
                //insertSQL.Parameters.Add(faq.Question);
                //insertSQL.Parameters.Add(faq.Answer);

                try
                {
                    insertSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return true;
        }

        public static bool Delete(int id)
        {
            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {
                conn.Open();
                SqliteCommand deleteSQL = new SqliteCommand("DELETE FROM Schedule WHERE Id = " + id, conn);

                try
                {
                    deleteSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return true;
        }
    }
}
