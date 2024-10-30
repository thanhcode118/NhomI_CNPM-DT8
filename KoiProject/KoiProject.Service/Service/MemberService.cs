using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Service.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<bool> RegisterMemberAsync(string username, string email, string password)
        {
            var member = new Member
            {
                Username = username,
                Email = email,
                Password = password
            };
            return await _memberRepository.RegisterMemberAsync(member);
        }

        public async Task<Member?> LoginMemberAsync(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    return null;
                }

                return await _memberRepository.LoginMemberAsync(email, password);
            }
            catch (Exception)
            {
                // Log exception here
                return null;
            }
        }
    }
}
