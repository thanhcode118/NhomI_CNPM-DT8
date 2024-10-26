using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiProject.WebApplication.Models // Thay 'YourNamespace' bằng namespace của bạn
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public bool LoginFailed { get; set; } = false; // Đảm bảo dòng này có mặt

        public void OnPost()
        {
            // Kiểm tra đăng nhập
            if (Username != "admin" || Password != "password") // Thay đổi điều kiện này theo logic của bạn
            {
                LoginFailed = true; // Gán true nếu đăng nhập thất bại
            }
            else
            {
                // Chuyển hướng đến trang chính
                RedirectToPage("/Home"); // Thay đổi đường dẫn này theo trang chính của bạn
            }
        }
    }
}
