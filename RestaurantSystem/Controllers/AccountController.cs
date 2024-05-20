using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Models;
using RestaurantSystem.Models.Data;
using RestaurantSystem.ViewModels;

namespace RestaurantSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly RestaurantContext _context;

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager, RestaurantContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.UserMail);
                if (user != null)
                {
                    var password = await _userManager.CheckPasswordAsync(user, login.Password);
                    if (password)
                    {
                        TempData["Error"] = "Wrong password";
                        var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                        if (result.Succeeded)
                        {
                            var perm = await _userManager.GetRolesAsync(user);
                            if (perm != null && perm.Count >= 1)
                            {
                                return RedirectToAction("Index", perm[0]);
                            }
                        }
                    }
                }
            }
            TempData["Error"] = "Wrong credentials";
            return View(login);
        }

        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (ModelState.IsValid && register.Password == register.ConfirmPassword)
            {
                var user = await _userManager.FindByEmailAsync(register.UserMail);
                if (user == null)
                {
                    user = new Account 
                    {
                        Email = register.UserMail,
                        UserName = register.UserMail
                    };

                    var userResp = await _userManager.CreateAsync(user, register.Password);
                    if (userResp.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, UserRole.User);
                        return RedirectToAction("Index", UserRole.User);
                    }
                }
            }

            TempData["Error"] = "User all ready exist or passwords are not equals";
            return View(register);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
