using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthScore.Web.Models
{
    public class Score
    {
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Health_Score { get; set; }
    }
}
