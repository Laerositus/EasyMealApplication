using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EasyMealManagementGUI.Models.ViewModels;
using EasyMealCore.DomainModel;

namespace EasyMealManagementGUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userMgr,
                SignInManager<ApplicationUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            //IdentitySeedData.EnsurePopulated(userMgr).Wait();
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        public ViewResult Register(string returnUrl)
        {
            return View(new RegisterModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user =
                    await userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                            loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View(loginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = registerModel.Username, Email = registerModel.Email , DOB = registerModel.DOB};
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect(registerModel?.ReturnUrl ?? "/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            ModelState.AddModelError(string.Empty, "Invalid username, email or password");
            return View(registerModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
