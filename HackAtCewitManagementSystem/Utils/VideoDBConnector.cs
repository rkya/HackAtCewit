using System;
using System.Collections.Generic;
using HackAtCewitManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Utils
{
    public static class VideoDBConnector
    {
        public static List<Video> GetVideos(string dataSource) {
            List<Video> videos = new List<Video>();

            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand(Constants.Sql.SELECT_ALL_VIDEOS, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var video = new Video
                    {
                        Title = rdr["Title"] == DBNull.Value ? "" : (string)rdr["Title"],
                        Url = rdr["Url"] == DBNull.Value ? "" : (string)rdr["Url"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"]
                    };

                    videos.Add(video);
                }
            }

            return videos;
        }

        public static Video GetVideo(string dataSource, int id)
        {
            Video video = null;

            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * FROM Video WHERE Id = " + id, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    video = new Video
                    {
                        Title = rdr["Title"] == DBNull.Value ? "" : (string)rdr["Title"],
                        Url = rdr["Url"] == DBNull.Value ? "" : (string)rdr["Url"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"]
                    };

                }
            }

            return video ?? new Video();
        }

        public static bool Create(string dataSource, Video video)
        {
            return InsertOrUpdate(dataSource, video);
        }

        public static bool Update(string dataSource, Video video)
        {
            return InsertOrUpdate(dataSource, video);
        }

        private static bool InsertOrUpdate(string dataSource, Video video)
        {
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();
                SqliteCommand insertSQL = new SqliteCommand("INSERT OR REPLACE INTO Video(Id, Title, Url) VALUES ((SELECT Id FROM Video WHERE Id = " + video.Id + "), '" + video.Title + "', '" + video.Url + "')", conn);

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

        public static bool Delete(string dataSource, int id)
        {
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();
                SqliteCommand deleteSQL = new SqliteCommand("DELETE FROM Video WHERE Id = " + id, conn);

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
