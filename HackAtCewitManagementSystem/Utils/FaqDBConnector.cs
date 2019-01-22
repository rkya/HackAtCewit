using System;
using System.Collections.Generic;
using HackAtCewitManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HackAtCewitManagementSystem.Utils
{
    public static class FaqDBConnector
    {
        public static List<Faq> GetFaqs(string dataSource) {
            List<Faq> faqs = new List<Faq>();

            using (SqliteConnection conn = new SqliteConnection(dataSource))
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

        public static Faq GetFaq(string dataSource, int id)
        {
            Faq faq = null;

            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * FROM Faq WHERE Id = " + id, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    faq = new Faq
                    {
                        Question = rdr["Question"] == DBNull.Value ? "" : (string)rdr["Question"],
                        Answer = rdr["Answer"] == DBNull.Value ? "" : (string)rdr["Answer"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"]
                    };

                }
            }

            return faq ?? new Faq();
        }

        public static bool Create(string dataSource, Faq faq) {
            return InsertOrUpdate(dataSource, faq);
        }

        public static bool Update(string dataSource, Faq faq)
        {
            return InsertOrUpdate(dataSource, faq);
        }

        private static bool InsertOrUpdate(string dataSource, Faq faq) {
            using (SqliteConnection conn = new SqliteConnection(dataSource))
            {
                conn.Open();
                SqliteCommand insertSQL = new SqliteCommand("INSERT OR REPLACE INTO Faq(Id, Question, Answer) VALUES ((SELECT Id FROM Faq WHERE Id = " + faq.Id + "), '" + faq.Question + "', '" + faq.Answer + "')", conn);

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
                SqliteCommand deleteSQL = new SqliteCommand("DELETE FROM Faq WHERE Id = " + id, conn);

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
