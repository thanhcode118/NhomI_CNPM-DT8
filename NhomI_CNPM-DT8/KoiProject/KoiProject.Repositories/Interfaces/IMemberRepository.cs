using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<bool> RegisterMemberAsync(Member member);
        Task<Member> LoginMemberAsync(string email, string password);
    }
}
