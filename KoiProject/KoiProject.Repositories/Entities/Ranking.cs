using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Entities
{
    public class Ranking
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
        public double Change { get; set; } // % thay đổi so với trước
    }
}
