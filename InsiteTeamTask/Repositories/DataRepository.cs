using InsiteTeamTask.MockData;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.Repositories
{
    public class DataRepository
    {
        public List<Attendance> GetAttendanceListForGame(int seasonId, int gameId)
        {
            MockDataService service = new MockDataService();

            Game game = service.Games().SingleOrDefault(g => g.SeasonId == seasonId && g.Id == gameId);

            if (game == null)
                return new List<Attendance>();

            List<Product> gameProducts = service.Products()
                .Where(p => p.SeasonId == game.SeasonId && (p.Type == ProductType.Member || (p.SeasonId == game.SeasonId && p.GameId == game.Id)))
                .ToList();
            List<Member> members = service.Members()
                .Where(m => gameProducts.Any(p => p.Type == ProductType.Member && p.Id == m.ProductId))
                .ToList();
            List<Ticket> tickets = service.Tickets()
                .Where(t => gameProducts.Any(p => p.Type == ProductType.Ticket && p.Id == t.ProductId))
                .ToList();

            List<Attendance> attendanceList = new List<Attendance>();

            for(int i = 0; i < members.Count; i++)
            {
                attendanceList.Add(new Attendance()
                {
                    Barcode = "N/A",
                    MemberId = members[i].Id
                });
            }

            for (int i = 0; i < tickets.Count; i++)
            {
                attendanceList.Add(new Attendance()
                {
                    Barcode = tickets[i].Barcode,
                    MemberId = 0
                });
            }

            return attendanceList;
        }

        public List<Attendance> GetAttendanceListForProduct(string productId)
        {
            MockDataService service = new MockDataService();

            var product = service.Products().SingleOrDefault(p => p.Id == productId);

            if (product == null)
                return new List<Attendance>();

            var attendanceList = new List<Attendance>();

            if (product.Type == ProductType.Member)
            {
                var member = service.Members().Single(m => m.ProductId == product.Id);
                attendanceList.Add(new Attendance()
                {
                    Barcode = "N/A",
                    MemberId = member.Id
                });
            }
            else if (product.Type == ProductType.Ticket)
            {
                var tickets = service.Tickets().Where(t => t.ProductId == product.Id);
                foreach (var ticket in tickets)
                {
                    attendanceList.Add(new Attendance()
                    {
                        Barcode = ticket.Barcode,
                        MemberId = 0
                    });
                }
            }

            return attendanceList;
        }

        public List<Season> GetSeasons(int gameId)
        {
            // I started doing this section before I realised it wasn't part of the spec ¯\_(ツ)_/¯

            MockDataService service = new MockDataService();

            var seasons = service.Seasons();
            var games = service.Games().Where(g => g.Id == gameId);

            if (games == null)
                return new List<Season>();

            var seasonIds = games.Select(g => g.SeasonId);

            return seasons.Where(s => seasonIds.Contains(s.Id)).ToList();
        }

        public List<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
