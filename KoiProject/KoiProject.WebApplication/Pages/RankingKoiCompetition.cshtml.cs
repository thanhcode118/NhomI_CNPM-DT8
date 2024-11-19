using KoiProject.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiProject.WebApplication.Pages
{
    public class RankingCompetitionModel : PageModel
    {
        private readonly IKoiServiceCompetition _koiService;

        public RankingCompetitionModel(IKoiServiceCompetition koiService)
        {
            _koiService = koiService;
        }

        public List<KoiManagement> Rankings { get; set; }

        public void OnGet()
        {
            // Generate random scores and get rankings
            _koiService.GenerateRandomScores();
            Rankings = _koiService.GetRanking();
        }
    }
}
