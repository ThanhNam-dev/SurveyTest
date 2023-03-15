using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveyTest.Business.Models.Data;
using SurveyTest.Business.Models;
using SurveyTest.Models;
using System.Diagnostics;

namespace SurveyTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly RoleManager<AppRoles> roleManager;
        private readonly SignInManager<AppUsers> signInManager;
        private readonly DataDbContext _context;
        public HomeController(UserManager<AppUsers> userManager, RoleManager<AppRoles> roleManager, SignInManager<AppUsers> signInManager, DataDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

    }
}