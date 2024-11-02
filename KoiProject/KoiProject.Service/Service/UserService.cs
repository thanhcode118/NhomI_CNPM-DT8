// UserService.cs
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;

namespace KoiProject.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            // Lưu trực tiếp mật khẩu đã mã hóa từ `RegisterModel`
            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            // Truy vấn người dùng với email và mật khẩu đã mã hóa từ `LoginModel`
            return await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
        }

        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _userRepository.IsUsernameTakenAsync(username);
        }

        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _userRepository.IsEmailTakenAsync(email);
        }
    }
}
