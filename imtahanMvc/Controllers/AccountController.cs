using imtahanMvc.DAL;
using imtahanMvc.Models;
using imtahanMvc.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imtahanMvc.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext context,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = new AppUser();
            {
                user.Name = vm.Name;
                user.SurName = vm.SurName;
                user.UserName = vm.UserName;
                user.Email = vm.Email;                
            }

            var result = await _userManager.CreateAsync(user ,vm.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            //await _userManager.AddToRoleAsync(user, "Member");

            await _signInManager.SignInAsync(user,true);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Sevh melumat daxil olundu");
                return View();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password,true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "bir az gozleyin ,sonra yeniden sinayin");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "yanlis melumat daxil olundu");
            }

            await _signInManager.SignInAsync(user,vm.RemeberMe);

            //if (ReturnUrl == null)
            //{
            //    return RedirectToAction(ReturnUrl);
            //}

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name ="Admin"
            });
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Member"
            });
            return RedirectToAction("Index","Home");
        }

    }
}
