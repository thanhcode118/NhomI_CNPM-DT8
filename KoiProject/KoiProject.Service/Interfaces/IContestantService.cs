using KoiProject.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IContestantService
{

    Task<bool> RegisterKoiAsync(KoiManagement koi);
}
