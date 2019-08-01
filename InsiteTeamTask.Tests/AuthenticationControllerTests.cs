using InsiteTeamTask.Controllers;
using InsiteTeamTask.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class AuthenticationControllerTests
    {
        private readonly string username = "fortress";
        private readonly string password = "insite";

        [TestMethod]
        public void Login_returns_OkObjectResult_containing_token()
        {
            // Arrange
            var controller = new AuthenticationController();

            // Act
            var login = new Login() { Username = username, Password = password };
            var result = controller.Login(login);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            
        }

        [TestMethod]
        public void Login_returns_BadRequest_if_username_null()
        {
            // Arrange
            var controller = new AuthenticationController();

            // Act
            var login = new Login() { Username = null, Password = password };
            var result = controller.Login(login);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Login_returns_BadRequest_if_password_null()
        {
            // Arrange
            var controller = new AuthenticationController();

            // Act
            var login = new Login() { Username = username, Password = null };
            var result = controller.Login(login);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Login_returns_Unauthorised_if_login_details_incorrect()
        {
            // Arrange
            var controller = new AuthenticationController();

            // Act
            var login = new Login() { Username = username, Password = "incorrectPassword" };
            var result = controller.Login(login);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
        }
    }
}
