using System;
using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using InsiteTeamTask.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Tests.Controllers
{
    [TestClass]
    public class AttendanceControllerTests
    {
        private AttendanceController sut;
        private Mock<IDataRepository> dataRepository = new Mock<IDataRepository>();
        private List<Attendance> attendances = new List<Attendance> { new Attendance { Barcode = "test", MemberId = 10 } };
        private string productId = "TEST_ID";
        private int seasonId = 10, gameId = 11;

        [TestInitialize]
        public void Setup()
        {
            sut = new AttendanceController(dataRepository.Object);
        }

        [TestMethod]
        public void Get_WhenPassedProductId_CallsDataRepository()
        {
            //Arrange
            dataRepository.Setup(x => x.GetAttendanceListFor(productId)).Returns(attendances);

            //Act
            var result = sut.Get(productId, null, null);

            //Assert
            var resultValue = result.Result as OkObjectResult;
            Assert.IsNotNull(resultValue);
            dataRepository.Verify(x => x.GetAttendanceListFor(productId), Times.Once);
            Assert.AreEqual(attendances, resultValue.Value);
        }

        [TestMethod]
        public void Get_WhenPassedSeasonIdGameId_GetsProductIdAndCallsDataRepository()
        {
            //Arrange
            var product = new Product { SeasonId = seasonId, GameId = gameId, Id = productId };
            dataRepository.Setup(x => x.GetProducts()).Returns(new List<Product> { product });
            dataRepository.Setup(x => x.GetAttendanceListFor(productId)).Returns(attendances);

            //Act
            var result = sut.Get(null, seasonId, gameId);

            //Assert
            var resultValue = result.Result as OkObjectResult;
            Assert.IsNotNull(resultValue);
            dataRepository.Verify(x => x.GetProducts(), Times.Once);
            dataRepository.Verify(x => x.GetAttendanceListFor(productId), Times.Once);
            Assert.AreEqual(attendances, resultValue.Value);
        }

        [TestMethod]
        public void Get_WhenNoProductExists_GetsProductIdAndCallsDataRepository()
        {
            //Arrange
            var product = new Product { SeasonId = seasonId, GameId = gameId, Id = productId };
            dataRepository.Setup(x => x.GetProducts()).Returns(new List<Product> { product });

            //Act
            var result = sut.Get(null, seasonId, gameId + 1);

            //Assert
            var resultValue = result.Result as NotFoundResult;
            Assert.IsNotNull(resultValue);
        }

        [TestMethod]
        public void Get_WhenNullArguments_ReturnsBadRequest()
        {
            //Arrange
            //Act
            var result = sut.Get(null, null, null);

            //Assert
            var resultValue = result.Result as BadRequestObjectResult;
            Assert.IsNotNull(resultValue);
        }
    }
}
