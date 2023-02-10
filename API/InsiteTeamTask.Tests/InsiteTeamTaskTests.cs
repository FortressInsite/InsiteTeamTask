using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class InsiteTeamTaskTests
    {
        private readonly IDataProvider dataProvider;
        public InsiteTeamTaskTests(IDataProvider dataProvider) 
        { 
            
            this.dataProvider = dataProvider;
            
        }
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var mockDataService = new DataService(this.dataProvider);
 
            // Act
            var attendance = mockDataService.GetAttendance();

            // Assert
            Assert.IsNotNull(attendance);
        }
    }
}
