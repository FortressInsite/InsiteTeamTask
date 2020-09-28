using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsiteTeamTask.Repositories;
using InsiteTeamTask.MockData;
using InsiteTeamTask.Models;
using Moq;

namespace InsiteTeamTask.Tests.Repositories
{
	[TestClass]
	public class DataRepositoryTests
	{
		private DataRepository sut;
		private Mock<IDataService> dataService = new Mock<IDataService>();

		[TestInitialize]
		public void Setup()
		{
			sut = new DataRepository(dataService.Object);
		}

		[TestMethod]
		public void GetAttendanceListFor_ReturnsCorrectData()
		{
			//Arrange
			dataService.Setup(x => x.Members()).Returns(new List<Member>());
			dataService.Setup(x => x.Products()).Returns(new List<Product>());
			dataService.Setup(x => x.Games()).Returns(new List<Game>());
			dataService.Setup(x => x.Seasons()).Returns(new List<Season>());

			//Act
			var result = sut.GetAttendanceListFor("");

			//Assert
		}
	}
}
