using AutoMapper;
using InsiteTeamTask.Logic.Attendence;
using InsiteTeamTask.Models;

namespace InsiteTeamTask.Services
{
    public class AttendenceViewService : IAttendenceViewService
    {
        private readonly IMapper _mapper;
        private readonly IAttendenceService _attendenceService;

        public AttendenceViewService(IMapper mapper, IAttendenceService attendenceService)
        {
            _mapper = mapper;
            _attendenceService = attendenceService;
        }
        public AttendenceViewModel GetAttendence(int gameNumber, int seasonNumber)
        {
            var dto = _attendenceService.GetAttendenceForGameNumberAndSeasonNumber(gameNumber, seasonNumber);

            return _mapper.Map<AttendenceViewModel>(dto);
        }

        public AttendenceViewModel GetAttendence(string productCode)
        {
            var dto = _attendenceService.GetAttendanceForProductCode(productCode);

            return _mapper.Map<AttendenceViewModel>(dto);
        }
    }
}