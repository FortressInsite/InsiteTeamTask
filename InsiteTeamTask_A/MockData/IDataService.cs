using InsiteTeamTask_A.Models;
using InsiteTeamTask_A.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask_A.MockData
{
    public interface IDataService
    {
        IEnumerable<Member> Members();

        IEnumerable<Product> Products();

        IEnumerable<Game> Games();

        IEnumerable<Season> Seasons();
    }
}
