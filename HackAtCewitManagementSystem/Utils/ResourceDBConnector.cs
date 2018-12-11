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
    public static class ResourceDBConnector
    {
        public static List<Resource> GetResources(string sqlQuery)
        {
            List<Resource> resources = new List<Resource>();

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand(sqlQuery, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var resource = new Resource
                    {
                        ProviderName = rdr["ProviderName"] == DBNull.Value ? "" : (string)rdr["ProviderName"],
                        Title = rdr["Title"] == DBNull.Value ? "" : (string)rdr["Title"],
                        Description = rdr["Description"] == DBNull.Value ? "" : (string)rdr["Description"],
                        Link = rdr["Link"] == DBNull.Value ? "" : (string)rdr["Link"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"]
                    };

                    resources.Add(resource);
                }
            }

            return resources;
        }

        public static Resource GetResource(int id)
        {
            Resource resource = null;

            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();

                SqliteCommand cmd = new SqliteCommand("SELECT * FROM Resource WHERE Id = " + id, conn);

                SqliteDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    resource = new Resource
                    {
                        ProviderName = rdr["ProviderName"] == DBNull.Value ? "" : (string)rdr["ProviderName"],
                        Title = rdr["Title"] == DBNull.Value ? "" : (string)rdr["Title"],
                        Description = rdr["Description"] == DBNull.Value ? "" : (string)rdr["Description"],
                        Link = rdr["Link"] == DBNull.Value ? "" : (string)rdr["Link"],
                        Id = rdr["Id"] == DBNull.Value ? -1 : (long)rdr["Id"]
                    };

                }
            }

            return resource ?? new Resource();
        }

        public static bool Create(Resource faq)
        {
            return InsertOrUpdate(faq);
        }

        public static bool Update(Resource faq)
        {
            return InsertOrUpdate(faq);
        }

        private static bool InsertOrUpdate(Resource resource)
        {
            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();
                SqliteCommand insertSQL = new SqliteCommand("INSERT OR REPLACE INTO Resource(Id, Title, Link, Description, ProviderName) VALUES ((SELECT Id FROM Resource WHERE Id = " + resource.Id + "), '" + resource.Title + "', '" + resource.Link + "', '" + resource.Description + "', '" + resource.ProviderName + "')", conn);
               
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
            using (SqliteConnection conn = new SqliteConnection("Data Source=test.db"))
            {
                conn.Open();
                SqliteCommand deleteSQL = new SqliteCommand("DELETE FROM Resource WHERE Id = " + id, conn);

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
