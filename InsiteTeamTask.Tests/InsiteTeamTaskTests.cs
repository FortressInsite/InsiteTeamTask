using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class InsiteTeamTaskTests
    {
        [TestMethod]
        public void GetAttendanceListForGame_doesnt_return_null()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var game = mockDataService.Games().First();
 
            // Act
            var attendanceList = repo.GetAttendanceListForGame(game.SeasonId, game.Id);

            // Assert
            Assert.IsNotNull(attendanceList);
        }

        [TestMethod]
        public void GetAttendanceListForGame_returns_empty_list_if_season_id_not_valid()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var games = mockDataService.Games();
            var fakeSeasonId = games.Max(g => g.SeasonId) + 1;
            var gameId = games.First().Id;

            // Act
            var attendanceList = repo.GetAttendanceListForGame(fakeSeasonId, gameId);

            // Assert
            Assert.IsNotNull(attendanceList);
            Assert.IsTrue(attendanceList.Count == 0);
        }

        [TestMethod]
        public void GetAttendanceListForGame_returns_empty_list_if_game_id_not_valid()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var games = mockDataService.Games();
            var seasonId = games.First().SeasonId;
            var fakeGameId = games.Max(g => g.Id) + 1;

            // Act
            var attendanceList = repo.GetAttendanceListForGame(seasonId, fakeGameId);

            // Assert
            Assert.IsNotNull(attendanceList);
            Assert.IsTrue(attendanceList.Count == 0);
        }

        [TestMethod]
        public void GetAttendanceListForGame_returns_attendance_for_specified_game()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();

            var games = mockDataService.Games();
            var game = games.First();
            var members = mockDataService.Members();
            var tickets = mockDataService.Tickets();
            var products = mockDataService.Products();

            var expectedProducts = products.Where(p => p.SeasonId == game.SeasonId && (p.Type == ProductType.Member || p.GameId == game.Id));
            var expectedMembers = members.Where(m => expectedProducts.Any(p => p.Type == ProductType.Member && p.Id == m.ProductId));
            var expectedTickets = tickets.Where(t => expectedProducts.Any(p => p.Type == ProductType.Ticket && p.Id == t.ProductId));

            // Act
            var attendanceList = repo.GetAttendanceListForGame(game.SeasonId, game.Id);

            // Assert
            Assert.IsTrue(attendanceList.All(a =>
                (a.MemberId != 0 && expectedMembers.Any(m => m.Id == a.MemberId)) ||
                (a.MemberId == 0 && expectedTickets.Any(t => t.Barcode == a.Barcode))
            ));
        }

        [TestMethod]
        public void GetAttendanceListForProduct_doesnt_return_null()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var product = mockDataService.Products().First();

            // Act
            var attendanceList = repo.GetAttendanceListForProduct(product.Id);

            // Assert
            Assert.IsNotNull(attendanceList);
        }

        [TestMethod]
        public void GetAttendanceListForProduct_returns_empty_list_if_productId_not_valid()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var fakeProductId = "SomeProductKey";

            // Act
            var attendanceList = repo.GetAttendanceListForProduct(fakeProductId);

            // Assert
            Assert.IsNotNull(attendanceList);
            Assert.IsTrue(attendanceList.Count == 0);
        }

        [TestMethod]
        public void GetAttendanceListForProduct_returns_single_result_if_product_type_is_member()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var memberProduct = mockDataService.Products().First(p => p.Type == ProductType.Member);
            var member = mockDataService.Members().First(m => m.ProductId == memberProduct.Id);

            // Act
            var attendanceList = repo.GetAttendanceListForProduct(memberProduct.Id);

            // Assert
            Assert.IsNotNull(attendanceList);
            Assert.IsTrue(attendanceList.Count == 1);
            Assert.IsTrue(attendanceList.First().MemberId == member.Id);
        }

        [TestMethod]
        public void GetAttendanceListForProduct_returns_list_of_results_if_product_type_is_ticket()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var ticketProduct = mockDataService.Products().First(p => p.Type == ProductType.Ticket);
            var ticket = mockDataService.Tickets().First(t => t.ProductId == ticketProduct.Id);

            // Act
            var attendanceList = repo.GetAttendanceListForProduct(ticketProduct.Id);

            // Assert
            Assert.IsNotNull(attendanceList);
            Assert.IsTrue(attendanceList.Count > 0);
            Assert.IsTrue(attendanceList.First().Barcode == ticket.Barcode);
        }

        [TestMethod]
        public void GetSeasons_doesnt_return_null()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var game = mockDataService.Games().First();

            // Act
            var seasonsList = repo.GetSeasons(game.Id);

            // Assert
            Assert.IsNotNull(seasonsList);
        }

        [TestMethod]
        public void GetSeasons_return_empty_list_if_gameId_not_valid()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();
            var fakeGameId = mockDataService.Games().Max(g => g.Id) + 1;

            // Act
            var seasonsList = repo.GetSeasons(fakeGameId);

            // Assert
            Assert.IsNotNull(seasonsList);
            Assert.IsTrue(seasonsList.Count == 0);
        }

        [TestMethod]
        public void GetSeasons_returns_all_seasons_containing_specified_game()
        {
            // Arrange
            var mockDataService = new MockDataService();
            var repo = new DataRepository();

            var products = mockDataService.Products();
            var seasons = mockDataService.Seasons();
            var game = mockDataService.Games().First();

            var expectedSeasonIds = products
                .Where(p => p.Type == ProductType.Ticket && p.GameId == game.Id)
                .Select(p => p.SeasonId)
                .Distinct();

            // Act
            var seasonsList = repo.GetSeasons(game.Id);

            // Assert
            Assert.IsNotNull(seasonsList);
            Assert.IsTrue(seasonsList.Count == expectedSeasonIds.Count());
            Assert.IsTrue(seasonsList.All(s => expectedSeasonIds.Contains(s.Id)));
        }
    }
}
