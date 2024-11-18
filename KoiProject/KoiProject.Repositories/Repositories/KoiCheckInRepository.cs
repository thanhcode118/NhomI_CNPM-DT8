using KoiProject.Repositories.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KoiCheckInRepository : IKoiCheckInRepository
{
    private readonly KoiCompetitionContext _context;

    public KoiCheckInRepository(KoiCompetitionContext context)
    {
        _context = context;
    }

    // Phương thức để gọi Stored Procedure CheckInKoi
    public async Task<string> CheckInKoiAsync(int koiID, string healthStatus, string notes)
    {
        try
        {
            // Thực thi Stored Procedure
            var koiIdParam = new SqlParameter("@KoiID", koiID);
            var healthStatusParam = new SqlParameter("@HealthStatus", healthStatus);
            var notesParam = new SqlParameter("@Notes", notes);

            await _context.Database
                .ExecuteSqlRawAsync("EXEC CheckInKoi @KoiID, @HealthStatus, @Notes", koiIdParam, healthStatusParam, notesParam);

            return "Check-in thành công!";
        }
        catch (Exception ex)
        {
            // Xử lý lỗi nếu có
            return $"Lỗi: {ex.Message}";
        }
    }
}

