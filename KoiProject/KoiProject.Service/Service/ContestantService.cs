using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ContestantService : IContestantService
{
    private readonly IContestantRepository _repository;

    public ContestantService(IContestantRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> RegisterKoiAsync(KoiManagement koi)
    {
        return await _repository.SaveKoiAsync(koi);
    }
}
