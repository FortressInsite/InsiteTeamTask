using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask.Logic.Configuration
{
    public interface IServicesConfigurationForLogic
    {
        IServiceCollection ConfigureServices(IServiceCollection serviceCollection);
    }
}