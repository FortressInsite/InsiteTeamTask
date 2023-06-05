using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class InsiteTeamTaskTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IDataProvider dataProvider = new DataProvider();
            var mockDataService = new DataService(dataProvider);

            var attendance = mockDataService.GetAttendance();

            Assert.IsNotNull(attendance);
        }

        [TestMethod]
        [DataRow("IT93")]
        [DataRow("")]
        public void TestMethod2(string productCode)
        {
            IDataProvider dataProvider = new DataProvider();
            var mockDataService = new DataService(dataProvider);

            var attendance = mockDataService.GetAttendanceForProduct(productCode);

            Assert.IsNotNull(attendance);
        }

        [TestMethod]
        [DataRow(16, 13)]
        [DataRow(0, 0)]
        public void TestMethod3(int seasonId, int gameNumber)
        {
            IDataProvider dataProvider = new DataProvider();
            var mockDataService = new DataService(dataProvider);

            var attendance = mockDataService.GetAttendanceForGame(seasonId, gameNumber);

            Assert.IsNotNull(attendance);
        }
    }
}
