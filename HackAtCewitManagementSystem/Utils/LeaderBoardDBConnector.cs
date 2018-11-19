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
    public static class LeaderBoardDBConnector
    {
        public static List<LeaderBoard> GetLeaderBoard(string sqlQuery)
        {
            List<LeaderBoard> leaderBoard = new List<LeaderBoard>();

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand(sqlQuery, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var userPosition = new LeaderBoard
                    {
                        Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"],
                        Score = rdr["Score"] == DBNull.Value ? -1 : (long)rdr["Score"],
                        LastUpdated = rdr["LastUpdated"] == DBNull.Value ? "" : (string)rdr["LastUpdated"],
                        Rank = rdr["Rank"] == DBNull.Value ? -1 : (long)rdr["Rank"]
                    };

                    leaderBoard.Add(userPosition);
                }
            }

            return leaderBoard;
        }
    }
}
