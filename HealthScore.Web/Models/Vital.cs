using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthScore.Web.Models
{
    public class Vital
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int ProviderId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Waist { get; set; }
        public int BloodPressureSystolic { get; set; }
        public int BloodPressureDiastolic { get; set; }
        public int CholesterolLDL { get; set; }
        public int CholesterolHDL { get; set; }
        public int Triglycerides { get; set; }
        public int TotalCholesterol { get; set; }
        public int BloodSugar { get; set; }
        public int OxygenSaturation { get; set; }

    }
}
