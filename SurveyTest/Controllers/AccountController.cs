using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyTest.Business.Models.Data;
using SurveyTest.Business.Models;
using SurveyTest.Business.Models.ViewModel;

namespace SurveyTest.Controllers
{
    [Route("tai-khoan")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly RoleManager<AppRoles> roleManager;
        private readonly SignInManager<AppUsers> signInManager;
        private readonly DataDbContext _context;
        public AccountController(UserManager<AppUsers> userManager, RoleManager<AppRoles> roleManager, SignInManager<AppUsers> signInManager, DataDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        [Route("dang-nhap")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {

            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("index", "home");
            }
            LoginViewModel model = new LoginViewModel
            {
                returnUrl = returnUrl,
                ExternalLogins =
                (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            this.ViewData["ReturnUrl"] = returnUrl;
            ViewData["Error"] = "";
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            var checkUserName = await _context.AppUsers.Where(x => x.IDSV == model.IDSV).FirstOrDefaultAsync();
            if (checkUserName != null)
            {
                var result = await signInManager.PasswordSignInAsync(
                    checkUserName.UserName,
                    model.Password,
                    model.RememberMe,
                    false);
                if (result.Succeeded)
                {

                    if (!string.IsNullOrEmpty(model.returnUrl))
                    {

                        return Redirect(model.returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
            }
            this.ViewData["ReturnUrl"] = returnUrl;
            ViewData["Error"] = "Tài khoản hoặc mật khẩu không chính xác";
            return View(model);
        }

        [Route("dang-xuat")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
