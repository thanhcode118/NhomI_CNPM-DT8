using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IKoiServiceCompetition
{
    void GenerateRandomScores();
    List<KoiManagement> GetRanking();
}
