using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IKoiCheckInRepository
{
    Task<string> CheckInKoiAsync(int koiID, string healthStatus, string notes);
}

