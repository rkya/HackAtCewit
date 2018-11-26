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

            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
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
                        LastUpdated = rdr["LastUpdated"] == DBNull.Value ? "" : (string)rdr["LastUpdated"]
                    };

                    leaderBoard.Add(userPosition);
                }
            }

            return leaderBoard;
        }

        public static LeaderBoard GetLeaderBoardRow(string username)
        {
            LeaderBoard leaderBoard = null;

            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * FROM LeaderBoard WHERE Username = '" + username + "' ORDER BY Score DESC", conn);

                SqliteDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    leaderBoard = new LeaderBoard
                    {
                        Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"],
                        Score = rdr["Score"] == DBNull.Value ? -1 : (long)rdr["Score"],
                        LastUpdated = rdr["LastUpdated"] == DBNull.Value ? "" : (string)rdr["LastUpdated"]
                    };

                }
            }

            return leaderBoard ?? new LeaderBoard();
        }

        public static bool Create(LeaderBoard leaderBoard)
        {
            return InsertOrUpdate(leaderBoard);
        }

        public static bool Update(LeaderBoard leaderBoard)
        {
            return InsertOrUpdate(leaderBoard);
        }

        private static bool InsertOrUpdate(LeaderBoard leaderBoard)
        {
            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {

                conn.Open();
                SqliteCommand insertSQL = new SqliteCommand("INSERT OR REPLACE INTO LeaderBoard(Username, Score, LastUpdated) VALUES ('" + leaderBoard.Username + "', " + leaderBoard.Score + ", datetime('now'))", conn);

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

        public static bool Delete(string username)
        {
            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {
                conn.Open();
                SqliteCommand deleteSQL = new SqliteCommand("DELETE FROM LeaderBoard WHERE Username = '" + username + "'", conn);

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

        public static List<LeaderBoard> GetUsersNotOnLeaderBoard()
        {
            List<LeaderBoard> leaderBoard = new List<LeaderBoard>();

            using (SqliteConnection conn = new SqliteConnection(Constants.DATA_SOURCE))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * FROM Checkin WHERE UserName NOT IN (SELECT DISTINCT Username FROM LeaderBoard)", conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var leaderBoardRow = new LeaderBoard
                    {
                        Username = rdr["Username"] == DBNull.Value ? "" : (string)rdr["Username"]
                    };

                    leaderBoard.Add(leaderBoardRow);
                }
            }

            return leaderBoard;
        }
    }
}
