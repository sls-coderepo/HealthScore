using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthScore.Web.Data;
using HealthScore.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthScore.Web.Controllers
{
    
    public class ProviderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProviderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var providerWithUser = await _context.Provider.ToListAsync();
            return View(providerWithUser);
        }
    }
}