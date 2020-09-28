using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class AttendanceTests
    {
        [TestMethod]
        public void WhenFetchingBySeasonAndGame_GivenValidInputs_AttendanceShouldNotBeNull()
        {
            // Arrange
            MockDataService mockDataService = new MockDataService();
            AttendanceService service = new AttendanceService();

            var seasons = mockDataService.Seasons();
            var games = mockDataService.Games();

            // Act
            List<Attendance> attendanceList = service.GetAttendanceListFor(seasons.First().Id, games.First().Id);

            // Assert
            Assert.IsNotNull(attendanceList);
        }

        [TestMethod]
        public void WhenFetchingByProduct_GivenValidInputs_AttendanceShouldNotBeNull()
        {
            // Arrange
            MockDataService mockDataService = new MockDataService();
            AttendanceService service = new AttendanceService();

            var products = mockDataService.Products();

            // Act
            List<Attendance> attendanceList = service.GetAttendanceListFor(products.First().Id);

            // Assert
            Assert.IsNotNull(attendanceList);
        }
    }
}
