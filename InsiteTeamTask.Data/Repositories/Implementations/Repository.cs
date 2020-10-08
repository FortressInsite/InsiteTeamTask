using AutoMapper;
using InsiteTeamTask.Data.MockData;

namespace InsiteTeamTask.Data.Repositories.Implementations
{
    internal abstract class Repository
    {
        protected readonly IDataService DataService;
        protected readonly IMapper Mapper;

        protected Repository(IMapper mapper, IDataService dataService)
        {
            Mapper = mapper;
            DataService = dataService;
        }
    }
}