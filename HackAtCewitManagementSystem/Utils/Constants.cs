using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HackAtCewitManagementSystem.Utils
{
    public class Constants
    {
        public static string DATA_SOURCE = "Data Source=hackatcewit.db";

        public class Sql
        {
            public static string SELECT_ALL_VIDEOS = "SELECT * from Video";
        }
    }
}
