using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.MockData
{
    public interface IDataService
    {
        IEnumerable<Member> Members();

        IEnumerable<Product> Products();

        IEnumerable<Game> Games();

        IEnumerable<Season> Seasons();
    }
}
