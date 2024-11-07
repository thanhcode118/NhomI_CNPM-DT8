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
    public class DetailsModel : PageModel
    {
        private readonly KoiProject.Repositories.Entities.KoiCompetitionContext _context;

        public DetailsModel(KoiProject.Repositories.Entities.KoiCompetitionContext context)
        {
            _context = context;
        }

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
    }
}
