using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiProject.Repositories.Entities;

namespace KoiProject.WebApplication.Pages.KoiFish
{
    public class EditModel : PageModel
    {
        private readonly KoiProject.Repositories.Entities.KoiCompetitionContext _context;

        public EditModel(KoiProject.Repositories.Entities.KoiCompetitionContext context)
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

            var koimanagement =  await _context.KoiManagements.FirstOrDefaultAsync(m => m.KoiId == id);
            if (koimanagement == null)
            {
                return NotFound();
            }
            KoiManagement = koimanagement;
           ViewData["UserEmail"] = new SelectList(_context.Users, "Email", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KoiManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiManagementExists(KoiManagement.KoiId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KoiManagementExists(int id)
        {
            return _context.KoiManagements.Any(e => e.KoiId == id);
        }
    }
}
