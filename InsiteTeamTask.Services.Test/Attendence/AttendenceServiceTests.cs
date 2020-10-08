using System.Collections.Generic;
using InsiteTeamTask.Data.Configuration;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Repositories.Interfaces;
using InsiteTeamTask.Logic.Attendence;
using InsiteTeamTask.Logic.Attendence.Actions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InsiteTeamTask.Services.Test.Attendence
{
    [TestClass]
    public class AttendenceServiceTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        private AttendenceService _attendenceService;

        [TestInitialize]
        public void TestIntialize()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            var mockAttendenceActionFactory = new Mock<IAttendenceActionFactory>();

            _attendenceService = new AttendenceService(_mockProductRepository.Object, mockAttendenceActionFactory.Object);
        }

        [TestMethod]
        public void GetAttendenceForGameNumberAndSeasonNumber_No_Products_Found_AttendenceDto_Returned()
        {
            var gameNumber = 0;
            var seasonNumber = 0;
            _mockProductRepository.Setup(x => x.GetProductByGameNumberAndSeasonNumber(gameNumber, seasonNumber)).Returns(new List<ProductDto>());

            var result = _attendenceService.GetAttendenceForGameNumberAndSeasonNumber(gameNumber, seasonNumber);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAttendenceForProductCode_No_Product_Found_AttendenceDto_Returned()
        {
            var productCode = "123";
            _mockProductRepository.Setup(x => x.GetProductByCode(productCode)).Returns((ProductDto) null);

            var result = _attendenceService.GetAttendanceForProductCode(productCode);

            Assert.IsNotNull(result);
        }
    }
}