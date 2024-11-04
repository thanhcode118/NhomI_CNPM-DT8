using Microsoft.AspNetCore.Mvc;
using KoiProject.Services.Interfaces;
using System.Threading.Tasks;

namespace KoiProject.Controllers
{
    public class RankingController : Controller
    {
        private readonly IRankingService _rankingService;

        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        public async Task<IActionResult> Index()
        {
            var rankings = await _rankingService.GetAllRankingsAsync();
            return View(rankings);
        }

        // Các action khác cho các thao tác CRUD nếu cần thiết
    }
}

