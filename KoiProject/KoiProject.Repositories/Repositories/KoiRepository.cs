using KoiProject.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KoiRepository : IKoiRepository
{
    private readonly KoiCompetitionContext _context;

    public KoiRepository(KoiCompetitionContext context)
    {
        _context = context;
    }

    public void RandomizeScores()
    {
        var koiList = _context.KoiManagement.ToList();
        Random random = new Random();

        foreach (var koi in koiList)
        {
            // Random điểm theo tiêu chí (chuyển đổi rõ ràng sang decimal)
            decimal dangScore = (decimal)(random.Next(0, 101) * 0.50); // 50% weight
            decimal colorScore = (decimal)(random.Next(0, 101) * 0.30); // 30% weight
            decimal patternScore = (decimal)(random.Next(0, 101) * 0.20); // 20% weight

            // Tính GPA
            decimal totalScore = dangScore + colorScore + patternScore;
            koi.Gpa = Math.Round(totalScore / 25.0M, 2); // 25.0M để ép kiểu thành decimal
        }

        _context.SaveChanges();
    }



    public List<KoiManagement> GetRanking()
    {
        return _context.KoiManagement
            .OrderByDescending(k => k.Gpa)
            .ToList();
    }
}

