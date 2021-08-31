using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Models;
using System.Collections.Generic;

namespace InsiteTeamTask.Services
{
    public interface IDataService
    {
        List<Attendance> GetAttendance();

        List<Attendance> GetAttendanceForGame(int seasonId, int gameNumber);

        List<Attendance> GetAttendanceForProduct(string productCode);
        List<Member> GetMembers();
        List<Ticket> GetTickets();
        List<Game> GetGames();
        List<Season> GetSeasons();
        List<string> GetProductCodes();
    }
}
