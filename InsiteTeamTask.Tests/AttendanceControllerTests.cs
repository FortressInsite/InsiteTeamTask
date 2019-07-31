using InsiteTeamTask.Controllers;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class AttendanceControllerTests
    {
        [TestMethod]
        public void GetByGame_returns_OkObjectResult()
        {
            //Arrange
            var controller = new AttendanceController();
            var mockDataService = new MockDataService();
            var game = mockDataService.Games().First();

            //Act
            var attendanceResults = controller.GetByGame(game.SeasonId, game.Id);

            //Assert
            Assert.IsNotNull(attendanceResults);
            Assert.IsInstanceOfType(attendanceResults.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetByGame_returns_BadRequestObjectResult_if_seasonId_less_than_one()
        {
            //Arrange
            var controller = new AttendanceController();
            var mockDataService = new MockDataService();
            var game = mockDataService.Games().First();

            //Act
            var attendanceResults = controller.GetByGame(0, game.Id);

            //Assert
            Assert.IsNotNull(attendanceResults);
            Assert.IsInstanceOfType(attendanceResults.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void GetByGame_returns_BadRequestObjectResult_if_gameId_less_than_one()
        {
            //Arrange
            var controller = new AttendanceController();
            var mockDataService = new MockDataService();
            var game = mockDataService.Games().First();

            //Act
            var attendanceResults = controller.GetByGame(game.SeasonId, 0);

            //Assert
            Assert.IsNotNull(attendanceResults);
            Assert.IsInstanceOfType(attendanceResults.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void GetByProduct_returns_OkObjectResult()
        {
            //Arrange
            var controller = new AttendanceController();
            var mockDataService = new MockDataService();
            var product = mockDataService.Products().First();

            //Act
            var attendanceResults = controller.GetByProduct(product.Id);

            //Assert
            Assert.IsNotNull(attendanceResults);
            Assert.IsInstanceOfType(attendanceResults.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetByProduct_returns_BadRequestObjectResult_if_productId_invalid()
        {
            //Arrange
            var controller = new AttendanceController();
            var mockDataService = new MockDataService();

            //Act
            var attendanceResults = controller.GetByProduct(null);

            //Assert
            Assert.IsNotNull(attendanceResults);
            Assert.IsInstanceOfType(attendanceResults.Result, typeof(BadRequestObjectResult));
        }
    }
}
