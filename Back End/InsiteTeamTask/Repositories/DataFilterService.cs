using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsiteTeamTask.Repositories
{
    public class DataFilterService
    {
        private readonly MockDataService _service;

        public DataFilterService()
        {
            _service = new MockDataService();
        }

        public List<int> GetAllSeasonNumbers()
        {
            return _service.Seasons().Select(season => season.Id).Distinct().ToList();
        }

        public List<int> GetAllGameNumbers()
        {
            return _service.Games().Select(game => game.Id).Distinct().ToList();
        }

        public List<string> GetAllProductIds()
        {
            return _service.Products().Select(product => product.Id).Distinct().ToList();
        }
    }
}
