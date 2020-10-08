using System.Collections.Generic;
using InsiteTeamTask.Data.DTOs;

namespace InsiteTeamTask.Data.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<TicketDto> GetTicketsByProductId(string productId);
    }
}