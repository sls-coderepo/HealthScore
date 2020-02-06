using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthScore.Web.Data;
using HealthScore.Web.Models;
using HealthScore.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthScore.Web.Controllers
{
    public class CompanyController : Controller

    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public CompanyController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var companyWithUser = await _context.Company.ToListAsync();
            return View(companyWithUser);
        }
        //GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyVM companyVM)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser 
                                { 
                                    UserName = companyVM.Email, 
                                    Email = companyVM.Email, 
                                    FirstName = companyVM.FirstName, 
                                    LastName = companyVM.LastName,
                                    PhoneNumber = companyVM.PhoneNumber
                                };

                var result = await _userManager.CreateAsync(user, companyVM.Password);
                
                if(result.Succeeded)
                {
                    _context.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = "2" });//roleId=2 company

                    var company = new Company()
                    {
                        Name = companyVM.Name,
                        Address = companyVM.Address,
                        ApplicationUserId = user.Id,
                        CompanyCode = companyVM.CompanyCode,
                        Email = companyVM.Email,
                        PhoneNumber = companyVM.PhoneNumber
                    };
                    _context.Company.Add(company);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            return View();           
        }
    }
}