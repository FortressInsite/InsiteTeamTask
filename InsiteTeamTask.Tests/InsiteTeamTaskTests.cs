using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using InsiteTeamTask_A.


namespace InsiteTeamTask_A.Tests
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

 
            // Act
            var attendanceList = repo.GetAttendanceListFor(games.First().Id);

            // Assert
            Assert.IsNotNull(attendanceList);
        }
    }
}
