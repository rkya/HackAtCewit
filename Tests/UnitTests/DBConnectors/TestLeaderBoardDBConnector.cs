using System;
using System.Collections.Generic;
using System.IO;
using HackAtCewitManagementSystem.Controllers;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Data.Sqlite;
using Xunit;

namespace Tests.UnitTests.DBConnectors
{
    public class TestLeaderBoardDBConnector
    {
        string dataSource;

        public TestLeaderBoardDBConnector() {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            dataSource = "Data Source=/Users/rohan/Documents/sbu/courses/524/HackAtCewitDesktopApplication/HackAtCewitManagementSystem/Tests/test.db;";
        }

        [Fact]
        public void TestEntireLeaderBoard()
        {
            List<LeaderBoard> userScores = LeaderBoardDBConnector.GetLeaderBoard(dataSource);

            Assert.NotNull(userScores);
        }

        [Fact]
        public void TestRetrieveSpecificUserScore()
        {
            LeaderBoard leaderBoardRow = LeaderBoardDBConnector.GetLeaderBoardRow(dataSource, "t2");

            Assert.NotNull(leaderBoardRow);
            Assert.Equal(90, leaderBoardRow.Score);
        }


        [Fact]
        public void TestInsert()
        {
            LeaderBoard userRank = new LeaderBoard();
            userRank.Username = "Test User";
            userRank.Score = 50;
            Assert.True(LeaderBoardDBConnector.Create(dataSource, userRank));
        }

        [Fact]
        public void TestUpdate()
        {
            LeaderBoard userRank = new LeaderBoard();
            userRank.Username = "Test User";
            userRank.Score = 40;
            Assert.True(LeaderBoardDBConnector.Update(dataSource, userRank));
        }

        [Fact]
        public void TestDelete()
        {
            LeaderBoard userRank = new LeaderBoard();
            userRank.Username = "Test Delete User";
            userRank.Score = 50;
            Assert.True(LeaderBoardDBConnector.Create(dataSource, userRank));

            List<LeaderBoard> leaderboard = LeaderBoardDBConnector.GetLeaderBoard(dataSource);

            Assert.NotNull(leaderboard);
            int count = leaderboard.Count;

            Assert.True(LeaderBoardDBConnector.Delete(dataSource, "Test Delete User"));

            leaderboard = LeaderBoardDBConnector.GetLeaderBoard(dataSource);

            Assert.NotNull(leaderboard);
            Assert.Equal(count - 1, leaderboard.Count);
        }

        [Fact]
        public void TestGetUsersNotOnLeaderBoard()
        {
            List<LeaderBoard> usersNotOnLeaderboard = LeaderBoardDBConnector.GetUsersNotOnLeaderBoard(dataSource);

            Assert.NotNull(usersNotOnLeaderboard);
        }
    }
}
