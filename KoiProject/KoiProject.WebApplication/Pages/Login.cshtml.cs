using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiProject.WebApplication.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IMemberService _memberService;

        public LoginModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra thông tin đăng nhập
            var member = await _memberService.LoginMemberAsync(Email, Password);
            if (member != null)
            {
                // Lưu thông tin người dùng vào session hoặc cookie nếu cần thiết
                HttpContext.Session.SetString("MemberID", member.MemberId.ToString());

                // Chuyển hướng đến trang dashboard
                return RedirectToPage("/Home");
            }

            // Nếu thông tin đăng nhập không hợp lệ
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
