using InsiteTeamTask.Controllers;
using InsiteTeamTask.Models;
using InsiteTeamTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InsiteTeamTask.Test.Controllers
{
    [TestClass]
    public class AttendanceControllerTests
    {
        private AttendanceController _controller;

        [TestInitialize]
        public void TestIntialize()
        {
            var mockService = new Mock<IAttendenceViewService>();
            mockService.Setup(x => x.GetAttendence(It.IsAny<int>(), It.IsAny<int>())).Returns(new AttendenceViewModel());
            mockService.Setup(x => x.GetAttendence(It.IsAny<string>())).Returns(new AttendenceViewModel());
            _controller = new AttendanceController(mockService.Object, new Logger<AttendanceController>(new LoggerFactory()));
        }

        [TestMethod]
        public void Get_GameNumber_SeasonNumber_No_Errors_Returns_Ok_Object_Result()
        {
            var result = _controller.Get(0, 0);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Get_ProductCode_No_Errors_Returns_Ok_Object_Result()
        {
            var result = _controller.Get(0, 0);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }
    }
}