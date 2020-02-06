using System;
using System.Collections.Generic;
using System.Text;
using HealthScore.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HealthScore.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<HealthyLiving> HealthyLiving { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Vital> Vital { get; set; }
       

    }
}
