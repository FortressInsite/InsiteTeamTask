using InsiteTeamTask.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class InsiteTeamTaskTests
    {
        [TestMethod]
        public void Assert_GetAttendanceListFor_gameNumber_Returns_Data()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var games = mockDataService.Games();

 
            // Act
            var attendanceList = repo.GetAttendanceListFor(games.First().Id);

            // Assert
            Assert.IsNotNull(attendanceList);
        }

        [TestMethod]
        public void Assert_GetAttendanceListFor_gameNumber_Returns_Correctly()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();

            var expectedBarcodes = new List<string>
            {
                "969312288",
                "946423612",
                "969341288",
                "969345292"
            };

            // Act
            var attendanceList = repo.GetAttendanceListFor(3);

            // Assert
            var barcodes = attendanceList.Select(attendance => attendance.Barcode).ToList();
            CollectionAssert.AreEqual(barcodes, expectedBarcodes);
        }

        [TestMethod]
        public void Assert_GetAttendanceListFor_gameNumber_seasonNumber_Returns_Correctly()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();

            var expectedBarcodes = new List<string>
            {
                "946423612"
            };

            // Act
            var attendanceList = repo.GetAttendanceListFor(3, 19);

            // Assert
            var barcodes = attendanceList.Select(attendance => attendance.Barcode).ToList();
            CollectionAssert.AreEqual(barcodes, expectedBarcodes);
        }


        [TestMethod]
        public void Assert_GetAttendanceListFor_productCode_Returns_Correctly()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();

            var expectedBarcodes = new List<string>
            {
                "964412136",
                "934414901",
                "966223434",
                "962421512",
                "964422511",
                "916394028",
                "901970287",
                "926340037",
                "912133969",
                "901223783",
                "951434130",
                "923093162"
            };

            // Act
            var attendanceList = repo.GetAttendanceListFor("CH5490");

            // Assert
            var barcodes = attendanceList.Select(attendance => attendance.Barcode).ToList();
            CollectionAssert.AreEqual(barcodes, expectedBarcodes);
        }
    }
}
