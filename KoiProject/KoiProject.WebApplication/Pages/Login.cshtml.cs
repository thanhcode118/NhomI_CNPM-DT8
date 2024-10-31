using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KoiProject.WebApplication.Pages
{
    public class LoginModel : PageModel
    {
        

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

