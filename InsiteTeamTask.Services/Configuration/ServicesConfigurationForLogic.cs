using AutoMapper;
using InsiteTeamTask.Logic.Attendence;
using InsiteTeamTask.Logic.Attendence.Actions;
using InsiteTeamTask.Logic.List;
using Microsoft.Extensions.DependencyInjection;

namespace InsiteTeamTask.Logic.Configuration
{
    public class ServicesConfigurationForLogic : IServicesConfigurationForLogic
    {
        public IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IAttendenceService, AttendenceService>()
                .AddScoped<IAttendenceAction, MemberAction>()
                .AddScoped<IAttendenceAction, TicketAction>()
                .AddScoped<IAttendenceActionFactory, AttendenceActionFactory>()
                .AddScoped<IListService, ListService>()
                .AddAutoMapper(typeof(ServicesMappingProfile));
        }
    }
}