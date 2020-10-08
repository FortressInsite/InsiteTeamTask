using InsiteTeamTask.Models;

namespace InsiteTeamTask.Services
{
    public interface IAttendenceViewService
    {
        AttendenceViewModel GetAttendence(int gameNumber, int seasonNumber);
        AttendenceViewModel GetAttendence(string productCode);
    }
}