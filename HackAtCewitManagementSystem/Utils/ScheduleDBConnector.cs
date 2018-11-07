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

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand(sqlQuery, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var schedule = new Schedule
                    {
                        StartTime = rdr["StartTime"] == DBNull.Value ? "" : (string)rdr["StartTime"],
                        EndTime = rdr["EndTime"] == DBNull.Value ? "" : (string)rdr["EndTime"],
                        EventDescription = rdr["EventDescription"] == DBNull.Value ? "" : (string)rdr["EventDescription"],
                        Room = rdr["Room"] == DBNull.Value ? "" : (string)rdr["Room"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"],
                        EventTitle = rdr["EventTitle"] == DBNull.Value ? "" : (string) rdr["EventTitle"],
                        Presenter = rdr["Presenter"] == DBNull.Value ? "" : (string) rdr["Presenter"]
                    };

                    schedules.Add(schedule);
                }
            }

            return schedules;
        }
    }
}
