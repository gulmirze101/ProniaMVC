using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia.ViewModels.UserViewModels;

namespace Pronia.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
   
        public async Task<IActionResult> RegisterAsync(RegisterVM vm)
        {
            if(!ModelState.IsValid) 
                return View(vm);


            var ExistUser = await _userManager.FindByNameAsync(vm.UserName);

            if(ExistUser is { })
            {
                ModelState.AddModelError("Username", "This username is already exist");
                return View(vm);
            }

            ExistUser = await _userManager.FindByEmailAsync(vm.EmailAddress);

            if (ExistUser is { })
            {
                ModelState.AddModelError(nameof(vm.EmailAddress), "This email is already exist");
                return View(vm);
            }

            AppUser appUser = new()
            {
                FullName = vm.FirstName + " " + vm.LastName,
                UserName = vm.UserName,
                Email = vm.EmailAddress
            };
            var result = await _userManager.CreateAsync(appUser, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(vm);
            }
            return Ok("Ok");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _userManager.FindByEmailAsync(vm.EmailAddress);

            if (user is null)
            {
                ModelState.AddModelError("", "Email or password is wrong");
                return View(vm);
            }

            var loginResult = await _userManager.CheckPasswordAsync(user, vm.Password);
            if (!loginResult)
            {
                ModelState.AddModelError("", "Email or password is wrong");
                return View(vm);
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
