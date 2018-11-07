using System;
using System.Collections.Generic;
using HackAtCewitManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Utils
{
    public static class FaqDBConnector
    {
        public static List<Faq> GetFaqs() {
            List<Faq> faqs = new List<Faq>();

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * from Faq", conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var faq = new Faq
                    {
                        Question = rdr["Question"] == DBNull.Value ? "" : (string)rdr["Question"],
                        Answer = rdr["Answer"] == DBNull.Value ? "" : (string)rdr["Answer"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"]
                    };

                    faqs.Add(faq);
                }
            }

            return faqs;
        }
    }
}
