using Microsoft.AspNetCore.Identity;
using SurveyTest.Business.BusinessAccess;
using SurveyTest.Business.Models.Data;
using SurveyTest.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Repository.Account
{
    public class AccountRepository
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly RoleManager<AppRoles> roleManager;
        private readonly SignInManager<AppUsers> signInManager;
        private readonly DataDbContext _context;
        public AccountRepository(UserManager<AppUsers> userManager, RoleManager<AppRoles> roleManager, SignInManager<AppUsers> signInManager, DataDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _context = context;
        }



    }
}
