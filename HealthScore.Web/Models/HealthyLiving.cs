using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthScore.Web.Models
{
    public class HealthyLiving
    {
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public SmokeBehavior SmokeBehavior { get; set; }
        public AlcoholBehavior AlcoholBehavior { get; set; }
        public DietBehavior DietBehavior { get; set; }
    }
}
