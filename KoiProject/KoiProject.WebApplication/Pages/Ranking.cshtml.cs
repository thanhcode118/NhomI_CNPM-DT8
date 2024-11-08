using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class Ranking : PageModel
{
    private readonly IRankingService _rankingService;

    public Ranking(IRankingService rankingService)
    {
        _rankingService = rankingService;
    }

    public List<KoiManagement> KoiList { get; set; }

    public void OnGet()
    {
        // Lấy danh sách cá Koi từ service và gán vào KoiList
        KoiList = _rankingService.GetRankingLeaderboard();
    }
}
