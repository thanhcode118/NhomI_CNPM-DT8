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
    public class IndexModel : PageModel
    {
        private readonly KoiProject.Repositories.Entities.KoiCompetitionContext _context;

        public IndexModel(KoiProject.Repositories.Entities.KoiCompetitionContext context)
        {
            _context = context;
        }

        public IList<KoiManagement> KoiManagement { get;set; } = default!;

        public async Task OnGetAsync()
        {
            KoiManagement = await _context.KoiManagements
                .Include(k => k.UserEmailNavigation).ToListAsync();
        }
    }
}
