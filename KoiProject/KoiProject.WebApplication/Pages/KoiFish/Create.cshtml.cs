using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiProject.Repositories.Entities;

namespace KoiProject.WebApplication.Pages.KoiFish
{
    public class CreateModel : PageModel
    {
        private readonly KoiProject.Repositories.Entities.KoiCompetitionContext _context;

        public CreateModel(KoiProject.Repositories.Entities.KoiCompetitionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserEmail"] = new SelectList(_context.Users, "Email", "Email");
            return Page();
        }

        [BindProperty]
        public KoiManagement KoiManagement { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.KoiManagements.Add(KoiManagement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
