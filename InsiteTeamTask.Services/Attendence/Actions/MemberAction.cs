using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.Repositories.Interfaces;

namespace InsiteTeamTask.Logic.Attendence.Actions
{
    class MemberAction : IAttendenceAction
    {
        private readonly IMembersRepository _membersRepository;

        public MemberAction(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }
        public AttendenceDto DoAction(ProductDto dto, AttendenceDto attendenceDto)
        {
            var member = _membersRepository.GetMembersByProductId(dto.Id);
            if (member != null)
            {
                attendenceDto.Members.Add(member);
            }

            return attendenceDto;
        }
    }
}