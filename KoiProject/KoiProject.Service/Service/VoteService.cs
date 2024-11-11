using KoiProject.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class VoteService : IVoteService
{
    private readonly IVoteRepository _voteRepository;

    public VoteService(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }
    public async Task<bool> IncreaseVoteAsync(int koiId)
    {
        // Tìm cá Koi theo ID
        var koi = await _voteRepository.GetKoiByIdAsync(koiId);
        if (koi == null)
        {
            return false; // Không tìm thấy cá Koi
        }

        // Tăng số lượng bình chọn
       // koi.VoteCount += 1;

        // Lưu thay đổi vào cơ sở dữ liệu
        await _voteRepository.UpdateKoiAsync(koi);

        return true; // Thành công
    }

    // Lấy danh sách tất cả các cá Koi
    public Task<IList<KoiManagement>> GetAllKoiAsync()
    {
        return _voteRepository.GetAllKoiAsync();
    }

    // Bình chọn cho cá Koi
    public async Task<bool> VoteForKoiAsync(int koiId, string voterEmail)
    {
        // Kiểm tra cá Koi có tồn tại hay không
        var koi = await _voteRepository.GetKoiByIdAsync(koiId);
        if (koi == null)
        {
            return false; // Không tìm thấy cá Koi
        }

        // Kiểm tra xem voter đã bình chọn chưa
        var existingVote = await _voteRepository.GetVoteByEmailAndKoiIdAsync(voterEmail, koiId);
        if (existingVote != null)
        {
            return false; // Người dùng đã bình chọn trước đó
        }

        // Thêm bình chọn mới
        var vote = new Vote
        {
            KoiID = koiId,
            VoterEmail = voterEmail
        };
        await _voteRepository.AddVoteAsync(vote);

        // Tăng VoteCount trong KoiManagement
      //  koi.VoteCount += 1;

        // Cập nhật thông tin cá Koi
        await _voteRepository.UpdateKoiAsync(koi);

        return true; // Bình chọn thành công
    }
}
