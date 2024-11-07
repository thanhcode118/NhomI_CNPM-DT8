using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiProject.Repositories.Entities;

namespace KoiProject.WebApplication.Pages.KoiFish
{
    public class DeleteModel : PageModel
    {
        private readonly KoiProject.Repositories.Entities.KoiCompetitionContext _context;

        public DeleteModel(KoiProject.Repositories.Entities.KoiCompetitionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KoiManagement KoiManagement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koimanagement = await _context.KoiManagements.FirstOrDefaultAsync(m => m.KoiId == id);

            if (koimanagement == null)
            {
                return NotFound();
            }
            else
            {
                KoiManagement = koimanagement;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koimanagement = await _context.KoiManagements.FindAsync(id);
            if (koimanagement != null)
            {
                KoiManagement = koimanagement;
                _context.KoiManagements.Remove(KoiManagement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
