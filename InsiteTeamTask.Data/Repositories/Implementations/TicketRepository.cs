using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Repositories.Interfaces;

namespace InsiteTeamTask.Data.Repositories.Implementations
{
    internal class TicketRepository : Repository, ITicketRepository
    {
        public TicketRepository(IMapper mapper, IDataService dataService) : base(mapper, dataService)
        {
        }

        public IEnumerable<TicketDto> GetTicketsByProductId(string productId)
        {
            var ticket = DataService.Tickets().Where(x => x.ProductId == productId);

            return Mapper.Map<IEnumerable<TicketDto>>(ticket);
        }
    }
}