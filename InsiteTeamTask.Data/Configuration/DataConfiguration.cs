using InsiteTeamTask.Data.MockData;
using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask.Data.Configuration
{
    public class DataConfiguration : IDataConfiguration
    {
        public IServiceCollection ConfigurServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDataConfiguration, DataConfiguration>()
                .AddScoped<IDataService, MockDataService>();

            return serviceCollection;
        }
    }
}