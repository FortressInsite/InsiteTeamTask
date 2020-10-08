using AutoMapper;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Repositories;
using InsiteTeamTask.Data.Repositories.Implementations;
using InsiteTeamTask.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask.Data.Configuration
{
    public class ServiceCollectionForData : IServiceCollectionForData
    {
        public IServiceCollection ConfigurServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IDataService, MockDataService>()
                .AddScoped<IGamesRepository, GamesRepository>()
                .AddScoped<IMembersRepository, MembersRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ITicketRepository, TicketRepository>()
                .AddScoped<ISeasonRepository, SeasonRepository>()
                .AddAutoMapper(typeof(DataMappingProfile));

            return serviceCollection;
        }
    }
}