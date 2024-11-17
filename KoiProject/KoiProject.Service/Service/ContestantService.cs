using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ContestantService : IContestantService
{
    private readonly IContestantRepository _contestantRepository;

    public ContestantService(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<List<KoiManagement>> GetAvailableKoiAsync()
    {
        return await _contestantRepository.GetAvailableKoiAsync();
   

    }

    public async Task<bool> RegisterContestantAsync(Contestant contestant)
    {
        // Logic kiểm tra thêm nếu cần
        return await _contestantRepository.SaveContestantAsync(contestant);
    }
}
