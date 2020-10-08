using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask.Data.Configuration
{
    public interface IDataConfiguration
    {
        IServiceCollection ConfigurServiceCollection(IServiceCollection serviceCollection);
    }
}