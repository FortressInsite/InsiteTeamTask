using System;
using System.Collections.Generic;
using System.Linq;
using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Logic.Attendence.Actions
{
    public class AttendenceActionFactory : IAttendenceActionFactory
    {
        private readonly Dictionary<ProductType, Func<IAttendenceAction>> _attendeceActions = new Dictionary<ProductType, Func<IAttendenceAction>>();

        public AttendenceActionFactory(IEnumerable<IAttendenceAction> attendenceActions)
        {
            //When multiple implementations are registered using the same Interface they will be returned as a list. Get the required type here, and match it to a ProductType.
            _attendeceActions.Add(ProductType.Member, () => attendenceActions.First(x => x.GetType() == typeof(MemberAction)));
            _attendeceActions.Add(ProductType.Ticket, () => attendenceActions.First(x => x.GetType() == typeof(TicketAction)));
        }

        public IAttendenceAction GetAction(ProductType type)
        {
            if (_attendeceActions.ContainsKey(type))
            {
                return _attendeceActions[type]();
            }
            else
            {
                throw new NotImplementedException("Provided Product Type is not implemented");
            }
        }
    }
}