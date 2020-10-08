using System;
using System.Collections.Generic;
using System.Linq;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Data.Repositories
{
    internal class DataRepository : IDataRepository
    {
        private readonly IDataService _dataService;

        public DataRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<Attendance> GetAttendanceListFor(int gameNumber, int seasonNumber)
        {
            var members = _dataService.Members().ToList();
            var tickets = _dataService.Tickets().ToList();
            var products = _dataService.Products().ToList();
            var games = _dataService.Games();
            var seasons = _dataService.Seasons();

            List<Attendance> attendanceList = new List<Attendance>();

            if (games.All(x => x.Id != gameNumber)) return attendanceList;
            if (seasons.All(x => x.Id != seasonNumber)) return attendanceList;

            foreach (var product in products)
            {
                if (product.GameId != gameNumber && product.SeasonId != seasonNumber) continue;

                var attendents = members.Where(x => x.ProductId == product.Id);
                attendanceList.AddRange(attendents.Select(x => new Attendance(){}));
            }

            return attendanceList;
        }

        public List<Season> GetSeasons(int eventId)
        {
            throw new NotImplementedException();
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
