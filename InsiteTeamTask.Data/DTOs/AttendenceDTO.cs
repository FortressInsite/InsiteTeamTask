using System.Collections.Generic;

namespace InsiteTeamTask.Data.DTOs
{
    public class AttendenceDto
    {
        public List<MemberDto> Members { get; set; }
        public List<TicketDto> Tickets { get; set; }

        public AttendenceDto()
        {
            Members = new List<MemberDto>();
            Tickets = new List<TicketDto>();
        }
    }
}
