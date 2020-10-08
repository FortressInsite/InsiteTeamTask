using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Repositories.Interfaces;

namespace InsiteTeamTask.Data.Repositories.Implementations
{
    internal class SeasonRepository : Repository, ISeasonRepository
    {
        public SeasonRepository(IMapper mapper, IDataService dataService) : base(mapper, dataService)
        {
        }

        public IEnumerable<SeasonDto> GetAllSeasons()
        {
            var seasons = DataService.Seasons();

            return Mapper.Map<IEnumerable<SeasonDto>>(seasons);
        }

        
    }
}