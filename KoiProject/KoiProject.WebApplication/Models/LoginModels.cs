using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiProject.Service;

namespace KoiProject.WebApplication
{
    public class LoginModel : PageModel
    {
        private readonly LoginService _loginService;

        public LoginModel(LoginService loginService)
        {
            _loginService = loginService;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // Xử lý khi trang được tải lần đầu
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_loginService.ValidateUser(Username, Password))
                {
                    // Đăng nhập thành công, chuyển hướng tới trang chính
                    return RedirectToPage("/Indexcshtml");
                }
                else
                {
                    // Đăng nhập thất bại
                    ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu.";
                }
            }
            return Page();
        }
    }
}
