using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vote
{
    [Key]
    public int VoteID { get; set; }

    [ForeignKey("KoiManagement")]
    public int KoiID { get; set; }

    public string VoterEmail { get; set; }
    public DateTime VoteDate { get; set; } = DateTime.Now;

    public KoiManagement Koi { get; set; }
}
