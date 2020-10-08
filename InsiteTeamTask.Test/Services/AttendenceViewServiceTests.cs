using AutoMapper;
using InsiteTeamTask.Configuration;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Logic.Attendence;
using InsiteTeamTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InsiteTeamTask.Test.Services
{
    [TestClass]
    public class AttendenceViewServiceTests
    {
        private AttendenceViewService _attendenceViewService;
        private Mock<IAttendenceService> _mockAttendenceService;

        [TestInitialize]
        public void TestIntialize()
        {
            _mockAttendenceService = new Mock<IAttendenceService>();
            _mockAttendenceService
                .Setup(x => x.GetAttendenceForGameNumberAndSeasonNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new AttendenceDto());

            _attendenceViewService = new AttendenceViewService(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(typeof(ViewModelMappingProfile)))), _mockAttendenceService.Object);
        }

        [TestMethod]
        public void GetAttendence_GameNumber_SeasonNumber_Returns_Not_Null()
        {
            var gameNumber = 0;
            var seasonNumber = 0;
            _mockAttendenceService
                .Setup(x => x.GetAttendenceForGameNumberAndSeasonNumber(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new AttendenceDto());

            var result = _attendenceViewService.GetAttendence(gameNumber, seasonNumber);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAttendence_ProductCode_Returns_Not_Null()
        {
            var productCode = "123";
            _mockAttendenceService
                .Setup(x => x.GetAttendanceForProductCode(productCode)).Returns(new AttendenceDto());

            var result = _attendenceViewService.GetAttendence(productCode);

            Assert.IsNotNull(result);
        }
    }
}