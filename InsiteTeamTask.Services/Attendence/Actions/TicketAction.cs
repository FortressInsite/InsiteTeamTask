using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Repositories.Interfaces;

namespace InsiteTeamTask.Logic.Attendence.Actions
{
    class TicketAction : IAttendenceAction
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketAction(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public AttendenceDto DoAction(ProductDto dto, AttendenceDto attendenceDto)
        {
            attendenceDto.Tickets.AddRange(_ticketRepository.GetTicketsByProductId(dto.Id));
            return attendenceDto;
        }
    }
}