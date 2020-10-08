using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask.Data.Configuration
{
    public interface IServiceCollectionForData
    {
        IServiceCollection ConfigurServiceCollection(IServiceCollection serviceCollection);
    }
}