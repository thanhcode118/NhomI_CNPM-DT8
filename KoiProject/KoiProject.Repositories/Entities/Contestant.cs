using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Entities
{
    public class Contestant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Email { get; set; }
        public string KoiId { get; set; }
        public string UserId { get; set; }
    }

}
