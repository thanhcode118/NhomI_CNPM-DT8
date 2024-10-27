using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Service
{
    public class LoginService : ILoginService
    {
        // Giả sử bạn có một danh sách người dùng để kiểm tra
        private List<User> users = new List<User>
        {
            new User { Username = "admin", Password = "minhtrinh123" },
            new User { Username = "user1", Password = "password1" }
        };

        public bool ValidateUser(string username, string password)
        {
            // Kiểm tra xem username và password có hợp lệ không
            return users.Any(user => user.Username == username && user.Password == password);
        }
    }

    // Lớp User để đại diện cho người dùng
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
