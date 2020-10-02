using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class InsiteTeamTaskTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var games = mockDataService.Games();
            var season = mockDataService.Seasons();
            var product = mockDataService.Products();

 
            // Act
            var attendanceList = repo.GetAttendanceListFor(games.First().Id, season.First().Id, product.First().Id);

            // Assert
            Assert.IsNotNull(attendanceList);
        }
    }
}
