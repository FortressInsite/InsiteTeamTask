using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Logic.Attendence.Actions
{
    public interface IAttendenceActionFactory
    {
        IAttendenceAction GetAction(ProductType type);
    }
}