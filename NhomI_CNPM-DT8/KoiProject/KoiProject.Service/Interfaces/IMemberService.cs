using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Service.Interfaces
{
    public interface IMemberService
    {
        Task<bool> RegisterMemberAsync(string username, string email, string password);
        Task<Member> LoginMemberAsync(string email, string password);
    }
}
