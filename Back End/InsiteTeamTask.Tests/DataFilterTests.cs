using InsiteTeamTask.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class DataFilterTests
    {
        [TestMethod]
        public void WhenFetchingAllSeasons_GivenSeasonsExists_AllIDsShouldBeUnique()
        {
            // Arrange
            DataFilterService service = new DataFilterService();

            // Act
            List<int> seasonIdList = service.GetAllSeasonNumbers();
            bool isUnique = seasonIdList.Distinct().Count() == seasonIdList.Count;

            // Assert
            Assert.IsTrue(isUnique);
        }

        [TestMethod]
        public void WhenFetchingAllGames_GivenGamesExists_AllIDsShouldBeUnique()
        {
            // Arrange
            DataFilterService service = new DataFilterService();

            // Act
            List<int> gameIdList = service.GetAllGameNumbers();
            bool isUnique = gameIdList.Distinct().Count() == gameIdList.Count;

            // Assert
            Assert.IsTrue(isUnique);
        }

        [TestMethod]
        public void WhenFetchingAllProducts_GivenProductsExists_AllIDsShouldBeUnique()
        {
            // Arrange
            DataFilterService service = new DataFilterService();

            // Act
            List<string> productIdList = service.GetAllProductIds();
            bool isUnique = productIdList.Distinct().Count() == productIdList.Count;

            // Assert
            Assert.IsTrue(isUnique);
        }
    }
}
