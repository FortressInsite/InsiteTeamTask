using InsiteTeamTask.Data.DTOs;

namespace InsiteTeamTask.Logic.Attendence.Actions
{
    public interface IAttendenceAction
    {
        AttendenceDto DoAction(ProductDto dto, AttendenceDto attendenceDto);
    }
}