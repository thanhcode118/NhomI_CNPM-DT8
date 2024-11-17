using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Interfaces
{
    public interface IContestantRepository
    {
        Task<List<KoiManagement>> GetAvailableKoiAsync();
        Task<bool> SaveContestantAsync(Contestant contestant);
    }
}

