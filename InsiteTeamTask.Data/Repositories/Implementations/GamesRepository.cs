using System.Collections.Generic;
using AutoMapper;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Repositories.Interfaces;

namespace InsiteTeamTask.Data.Repositories.Implementations
{
    internal class GamesRepository :Repository, IGamesRepository
    {
        public GamesRepository(IMapper mapper, IDataService dataService) : base(mapper, dataService)
        {
        }

        public IEnumerable<GameDto> GetAllGames()
        {
            return Mapper.Map<IEnumerable<GameDto>>(DataService.Games());
        }
    }
}