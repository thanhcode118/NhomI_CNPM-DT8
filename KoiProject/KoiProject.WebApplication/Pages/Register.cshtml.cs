using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiProject.WebApplication.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IMemberService _memberService;

        public RegisterModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra xem mật khẩu có khớp không
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }

            // Tạo đối tượng Member
            var memberCreated = await _memberService.RegisterMemberAsync(Username, Email, Password);
            if (memberCreated)
            {
                // Chuyển hướng đến trang đăng nhập
                return RedirectToPage("/Login");
            }

            // Nếu đăng ký không thành công
            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return Page();
        }
    }
}
