using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcDay2Task.Models;
using MvcDay2Task.ViewModel;

namespace MvcDay2Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            UserViewModel userViewModel = new UserViewModel();

            return View(userViewModel);
        }

        [ValidateAntiForgeryToken]//check the token which is given to client in httpGet request to open form
        [HttpPost]
        public async Task<IActionResult> SaveRegister(UserViewModel userViewModel) 
        {
            //ApplicationUser applicationUser = new ApplicationUser();
            //UserManager<applicationUser> userManager = new UserManager<applicationUser>();
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();

                applicationUser.UserName = userViewModel.UserName;
                applicationUser.PasswordHash = userViewModel.PassWord;
                applicationUser.Address = userViewModel.Address;

                IdentityResult result = await userManager.CreateAsync(applicationUser,userViewModel.PassWord);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(applicationUser, false);
                    await userManager.AddToRoleAsync(applicationUser,"Admin");//assign user to valid role 
                    return RedirectToAction("Index", "Instructor");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            
            return View("Register", userViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginUserViewModel loginUserViewModel = new LoginUserViewModel();
            return View("Login", loginUserViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel loginUserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? appUser = await userManager.FindByNameAsync(loginUserViewModel.Name);

                if (appUser == null)
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return View("Login", loginUserViewModel);
                }

                bool state = await userManager.CheckPasswordAsync(appUser, loginUserViewModel.PassWord);
                if (state)
                {
                    // Sign in user with cookies
                    await signInManager.SignInAsync(appUser, loginUserViewModel.RememberMe);
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View("Login",loginUserViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
