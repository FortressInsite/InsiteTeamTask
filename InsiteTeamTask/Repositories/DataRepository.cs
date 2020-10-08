using InsiteTeamTask.MockData;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly IDataService _dataService;
        public DataRepository(IDataService dataService)
        {
            _dataService = dataService;
        }
      
        public List<Attendance> GetAttendanceListForProduct(string prodId)
        {
            var attendanceList = new List<Attendance>();
            if(prodId != null){
            attendanceList.Union(_dataService.Tickets().Where(ticket => ticket.ProductId == prodId)
            .Select(ticket => new Attendance{
                MemberId = 0,
                Barcode = ticket.Barcode
            }));

            attendanceList.Union(_dataService.Members().Where(member => member.ProductId == prodId)
            .Select(member => new Attendance {
                MemberId = member.Id,
                Barcode = "N/A"
            }));
            }
            return attendanceList;


        }

        public List<Attendance> GetAttendanceForGame(int gameId, int seasonId)
        {
            var attendanceList = new List<Attendance>();

            attendanceList.AddRange(_dataService.Products().Where(prod => prod.GameId == gameId && prod.SeasonId == seasonId).Select(prod => new Attendance
            {
                Barcode = "N/A",
                MemberId = prod.GameId
            }));

            return attendanceList;
    
        }

        public List<Game> GetAllGames()
        {
            return _dataService.Games().ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _dataService.Products().ToList();
        }

        public List<Season> GetAllSeasons()
        {
            return _dataService.Seasons().ToList();
        }
    }
}
