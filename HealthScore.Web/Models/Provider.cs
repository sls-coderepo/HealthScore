using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthScore.Web.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProviderCode { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
