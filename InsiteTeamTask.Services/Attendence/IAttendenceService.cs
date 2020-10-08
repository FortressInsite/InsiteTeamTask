using InsiteTeamTask.Data.DTOs;

namespace InsiteTeamTask.Logic.Attendence
{
    public interface IAttendenceService
    {
        AttendenceDto GetAttendenceForGameNumberAndSeasonNumber(int gameNumber, int seasonNumber);
        AttendenceDto GetAttendanceForProductCode(string productCode);
    }
}