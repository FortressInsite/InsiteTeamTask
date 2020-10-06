using InsiteTeamTask_A;
using InsiteTeamTask_A.Repositories;
using NUnit.Framework;



namespace InsiteTeamTask.Test
{

    [TestFixture]
    class InsiteTeamTaskTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TestCase]
        public void TestGetAttendanceListByGameNumber()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var games = mockDataService.Games();


            // Act
            var attendanceList = repo.GetAttendanceListByGameNumber(3);

            // Assert
            Assert.AreEqual(attendanceList);
        }

    }
}
