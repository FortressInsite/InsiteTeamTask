using InsiteTeamTask_A.Repositories;
using NUnit.Framework;

namespace InsiteTeamTask.Test
{
    [TestFixture]
    public class InsiteTeamTaskTests
    {
        [TestCase(12,3,4)]
        [TestCase(16,12,2)]
        [TestCase(19,3,6)]
        [TestCase(19,4,17)]
        [TestCase(19,5,8)]
        
        public void GetAttendanceListBySeasonAndGame(int x, int y, int expected)
        {
            //Arrange
            var instance = new DataRepository();

            //Act
            var actual = instance.GetAttendanceListBySeasonAndGame(x,y).Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("MN319A",3)]
        [TestCase("LV302S", 3)]
        [TestCase("BM1249", 1)]
        [TestCase("AR3942", 1)]
        [TestCase("CH5490", 12)]
        [TestCase("IT20", 1)]
        [TestCase("IT93", 1)]
        [TestCase("IT52", 1)]
        [TestCase("IT49", 1)]
        [TestCase("IT68", 1)]
        public void GetAttendanceListByProductCode(string x, int expected)
        {
            // Arrange
            var instance = new DataRepository();

            //Act
            var actual = instance.GetAttendanceListByProductCode(x).Count;

            //Assert.AreEqual
            Assert.AreEqual(expected, actual);
        }



    }
}
