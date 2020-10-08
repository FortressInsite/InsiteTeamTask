using System.Collections.Generic;
using InsiteTeamTask.Data.Models;

namespace InsiteTeamTask.Data.MockData
{
    internal interface IDataService
    {
        IEnumerable<Member> Members();

        IEnumerable<Product> Products();

        IEnumerable<Game> Games();

        IEnumerable<Season> Seasons();
        IEnumerable<Ticket> Tickets();
    }
}
