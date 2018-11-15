using System;
using System.Collections.Generic;
using HackAtCewitManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Utils
{
    public static class VideoDBConnector
    {
        public static List<Video> GetVideos() {
            List<Video> videos = new List<Video>();

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * from Video", conn);

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
    }
}
