using KoiProject.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KoiService : IKoiService
{
    private readonly KoiCompetitionContext _context;

    public KoiService(KoiCompetitionContext context)
    {
        _context = context;
    }

    public async Task<List<KoiClassification>> GetClassifiedKoiAsync()
    {
        return await _context.Set<KoiClassification>()
            .FromSqlRaw("EXEC ClassifyKoi")
            .ToListAsync();
    }

}
