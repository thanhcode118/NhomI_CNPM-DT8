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
            try
            {

                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var member = await _memberService.LoginMemberAsync(Email, Password);

                if (member != null)
                {
                    // Lưu thông tin session
                    HttpContext.Session.SetString("MemberID", member.MemberId.ToString());
                    HttpContext.Session.SetString("Username", member.Username);
                    return RedirectToPage("/Dashboard");

                }
                return RedirectToPage("/Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();

            }

        }
    }
}

