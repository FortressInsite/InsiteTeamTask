using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.Repositories
{
    public interface IDataRepository
    {
        List<Attendance> GetAttendanceListForProduct(string prodId);
        List<Attendance> GetAttendanceForGame(int gameId, int seasonId);
        List<Season> GetAllSeasons();
        List<Game> GetAllGames();
        List<Product> GetAllProducts();
    }
}
