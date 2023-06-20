using InsiteTeamTask.Models;
using System.Collections.Generic;

namespace InsiteTeamTask.Services
{
    public interface IDataService
    {
        IEnumerable<Attendance> GetAttendance();

        IEnumerable<Attendance> GetAttendanceForGame(int seasonId, int gameNumber);

        IEnumerable<Attendance> GetAttendanceForProduct(string productCode);
    }
}
