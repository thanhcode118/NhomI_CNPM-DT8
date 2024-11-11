//using KoiProject.Repositories.Entities;
//using KoiProject.Repositories.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KoiProject.Repositories.Repositories
//{
//    public class RankingRepository : IRankingRepository
//    {
//        private readonly KoiCompetitionContext _context;

//        public RankingRepository(KoiCompetitionContext context)
//        {
//            _context = context;
//        }

//        public List<KoiManagement> GetRankingLeaderboard()
//        {
//            return _context.KoiManagements
//                           .OrderByDescending(k => k.VoteCount)
//                           .ToList();
//        }

       
//    }

//}
