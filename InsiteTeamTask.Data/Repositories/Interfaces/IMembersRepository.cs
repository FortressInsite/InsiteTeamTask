using System.Collections.Generic;
using InsiteTeamTask.Data.DTOs;

namespace InsiteTeamTask.Data.Repositories.Interfaces
{
    public interface IMembersRepository
    {
        MemberDto GetMembersByProductId(string productId);
    }
}