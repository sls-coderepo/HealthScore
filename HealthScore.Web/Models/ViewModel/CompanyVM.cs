using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthScore.Web.Models.ViewModel
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyCode { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmployeeSSN { get; set; }

    }
}
