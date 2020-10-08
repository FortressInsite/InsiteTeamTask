using System.Collections.Generic;

namespace InsiteTeamTask.Models
{
    public class AttendenceViewModel
    {
        public List<MemberViewModel> Members { get; set; }
        public List<TicketViewModel> Tickets { get; set; }
    }
}