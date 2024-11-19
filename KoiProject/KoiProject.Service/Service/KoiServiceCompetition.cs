using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KoiServiceCompetition : IKoiServiceCompetition
{
    private readonly IKoiRepository _koiRepository;

    public KoiServiceCompetition(IKoiRepository koiRepository)
    {
        _koiRepository = koiRepository;
    }

    public void GenerateRandomScores()
    {
        _koiRepository.RandomizeScores();
    }

    public List<KoiManagement> GetRanking()
    {
        return _koiRepository.GetRanking();
    }
}
