using System.Collections.Generic;
using HackAtCewitManagementSystem.Models;
using HackAtCewitManagementSystem.Utils;
using Xunit;

namespace Tests.UnitTests.DBConnectors
{
    public class TestVideoDBConnector
    {
        string dataSource;

        public TestVideoDBConnector() {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            dataSource = "Data Source=/Users/rohan/Documents/sbu/courses/524/HackAtCewitDesktopApplication/HackAtCewitManagementSystem/Tests/test.db;";
        }

        [Fact]
        public void TestRetrieveAll()
        {
            List<Video> videos = VideoDBConnector.GetVideos(dataSource);

            Assert.NotNull(videos);
        }

        [Fact]
        public void TestRetrieveSpecific()
        {
            Video video = VideoDBConnector.GetVideo(dataSource, 1);

            Assert.NotNull(video);
            Assert.Equal("CEWIT", video.Title);
            Assert.Equal("https://www.youtube.com/embed/i9TRte-Nrz0", video.Url);
        }


        [Fact]
        public void TestInsert()
        {
            List<Video> videos = VideoDBConnector.GetVideos(dataSource);

            Assert.NotNull(videos);
            int count = videos.Count;

            Video video = new Video();
            video.Title = "Test";
            video.Url = "www.google.com";
            Assert.True(VideoDBConnector.Create(dataSource, video));


            videos = VideoDBConnector.GetVideos(dataSource);
            Assert.NotNull(videos);
            Assert.Equal(count + 1, videos.Count);
        }

        [Fact]
        public void TestUpdate()
        {
            Video video = new Video();
            video.Title = "Test";
            video.Url = "www.google.com";
            Assert.True(VideoDBConnector.Update(dataSource, video));
        }

        [Fact]
        public void TestDelete()
        {
            Video video = new Video();
            video.Title = "Test";
            video.Url = "www.google.com";
            Assert.True(VideoDBConnector.Create(dataSource, video));

            Assert.True(FaqDBConnector.Delete(dataSource, 1));
        }
    }
}
