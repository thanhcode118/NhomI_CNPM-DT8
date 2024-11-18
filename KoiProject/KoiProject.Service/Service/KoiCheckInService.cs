using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KoiCheckInService : IKoiCheckInService
{
    private readonly IKoiCheckInRepository _repository;

    public KoiCheckInService(IKoiCheckInRepository repository)
    {
        _repository = repository;
    }

    // Phương thức gọi Repository để thực hiện check-in
    public async Task<string> CheckInKoiAsync(int koiID, string healthStatus, string notes)
    {
        // Gọi repository để thực hiện check-in
        var result = await _repository.CheckInKoiAsync(koiID, healthStatus, notes);
        return result;
    }
}
