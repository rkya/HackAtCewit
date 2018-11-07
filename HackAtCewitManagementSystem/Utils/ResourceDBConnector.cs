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
    }
}
