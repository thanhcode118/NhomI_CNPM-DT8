using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiProject.WebApplication.Pages
{
    public class Orders : PageModel
    {
		private readonly IRankingService _rankingService;

		public Orders(IRankingService rankingService)
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
}
