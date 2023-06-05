using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Models;
using InsiteTeamTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class InsiteTeamTaskTests
    {
        [TestMethod]
        public void GetAttendance()
        {
            var dataProvider = new DataProvider();
            var DataService = new DataService(dataProvider);
            var Attendance = DataService.GetAttendance();
            Assert.IsNotNull(Attendance);
        }

        [TestMethod]
        [DataRow("IT93")]
        [DataRow("")]
        public void GetAttendanceForProduct(string productCode)
        {
            var dataProvider = new DataProvider();
            var DataService = new DataService(dataProvider);
            var Attendance = DataService.GetAttendanceForProduct(productCode);
            Assert.IsNotNull(Attendance);
        }

        [TestMethod]
        [DataRow(16, 13)]
        [DataRow(0, 0)]
        public void GetAttendanceForGame(int seasonId, int gameNumber)
        {
            var dataProvider = new DataProvider();
            var DataService = new DataService(dataProvider);
            var Attendance = DataService.GetAttendanceForGame(seasonId, gameNumber);
            Assert.IsNotNull(Attendance);
        }
    }
}
