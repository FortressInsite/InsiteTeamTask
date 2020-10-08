using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InsiteTeamTask.Data.DTOs;
using InsiteTeamTask.Data.MockData;
using InsiteTeamTask.Data.Repositories.Interfaces;

namespace InsiteTeamTask.Data.Repositories.Implementations
{
    internal class MembersRepository : Repository, IMembersRepository
    {
        public MembersRepository(IMapper mapper, IDataService dataService) : base(mapper, dataService)
        {
        }

        public MemberDto GetMembersByProductId(string productId)
        {
            var member = DataService.Members().FirstOrDefault(x => x.ProductId == productId);

            return member == null ? null : Mapper.Map<MemberDto>(member);
        }
    }
}