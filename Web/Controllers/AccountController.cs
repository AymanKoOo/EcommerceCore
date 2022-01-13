using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entites;
using Core.Entites.Common;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        //usermanger
        //signInManager
        //roleManger

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            this.unitOfWork = unitOfWork;
            _signInManger = signInManager;
            _roleManager = roleManager;
        }


        /////Helper Funtions////
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            if (await _userManager.FindByEmailAsync(email) == null) return false;
            else return true;
        }
        ////// //////// ////// /////// /////

        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View("~/Views/Account/LoginRegister.cshtml");
        }


        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                    return Redirect(ViewBag.ReturnUrl);

                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Account/LoginRegister.cshtml");
        }


        //Check Email Exist
        //Check UserName Exist
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (model == null) return NotFound();

            if (ModelState.IsValid)
            {
                if (await CheckEmailExistsAsync(model.Email))
                {
                    return BadRequest("Email is already Used");
                }

                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.UserName
                };

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await _signInManger.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return Ok();
        }



        private async Task createRole()
        {
            if (_roleManager.Roles.Count() < 1)
            {
                var role = new ApplicationRole
                {
                    Name = "Admin"
                };
                await _roleManager.CreateAsync(role);

                role = new ApplicationRole
                {
                    Name = "User"
                };
                await _roleManager.CreateAsync(role);
            }
        }

        private async Task CreateAddmin()
        {
            var admin = await _userManager.FindByNameAsync("Admin");
            if (admin == null)
            {
                var user = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    EmailConfirmed = true
                };
                var x = await _userManager.CreateAsync(user, "Mhnsaa4pizza#");
                if (x.Succeeded)
                {
                    if (await _roleManager.RoleExistsAsync("Admin"))
                        await _userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

        public async void AddCookies(string username, string roleName, string userId, bool remeber,string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, roleName),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            if (remeber)
            {
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = remeber,
                    ExpiresUtc = DateTime.UtcNow.AddDays(10)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
            else
            {
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = remeber,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
        }

        //Check Email Exist
        //Check UserName Exist
        //private async Task<string> GertRoleNameByUserId(string userId)
        //{
        //    var userRole = await _db.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
        //    if (userRole != null)
        //    {
        //        return await _db.Roles.Where(x => x.Id == userRole.RoleId).Select(x => x.Name).FirstOrDefaultAsync();
        //    }
        //    return null;
        //}
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {

            await createRole();
            await CreateAddmin();

            if (model == null) return NotFound();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null) return NotFound();

            var result = await _signInManger.PasswordSignInAsync(user, model.Password, true, true);

            if (result.Succeeded)
            {
                if (await _roleManager.RoleExistsAsync("User"))
                {
                    if (!await _userManager.IsInRoleAsync(user, "User") && !await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                }

                var roleName = "Admin";
                if (roleName != null)
                {
                    AddCookies(user.UserName, roleName, user.Id, true,model.Email);
                }
                return Ok();
            }
            else if (result.IsLockedOut)
            {
                return Unauthorized("User account is locked");
            }
            else
            {
                return BadRequest(result.IsNotAllowed);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        ////

        [HttpGet]
        [Route("EditCustomerinfo")]
        public async Task<IActionResult> EditCustomerinfo()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var user =await unitOfWork.Admin.GetUser(email);
                    return View(user);
                }
                else
                {
                    return View("/");
                }
            }
        }

        [HttpPost]
        [Route("EditCustomerinfo")]
        public async Task<IActionResult> EditCustomerinfo(UserData model)
        {
           
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                {
                    if (!string.IsNullOrEmpty(email)&&model!=null)
                    {
                        var user = await unitOfWork.Admin.GetUser(email);
                        user.UserName = model.UserName;
                        user.Email = model.Email;
                        user.Country = model.Country;
                        user.PhoneNumber = model.PhoneNumber;
                        unitOfWork.Admin.EditUser(user);
                        unitOfWork.Save();
                        return View("/");
                    }
                    else
                    {
                        return View("/");
                    }
              
            }
        }


        [HttpGet]
        [Route("EditAddresses")]
        public async Task<IActionResult> EditAddresses()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var user = await unitOfWork.Admin.GetUserAndAddress(email);
                    return View(user.ShippingAddress);
                }
                else
                {
                    return View("/");
                }
            }
        }
        [HttpPost]
        [Route("EditAddresses")]
        public async Task<IActionResult> EditAddresses(Address model)
        {

            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            {
                if (!string.IsNullOrEmpty(email) && model != null)
                {
                    var user = await unitOfWork.Admin.GetUserAndAddress(email);
                   
                    user.ShippingAddress = model;
                    unitOfWork.Admin.EditUser(user);
                    unitOfWork.Save();
                    return View("/");
                }
                else
                {
                    return View("/");
                }
            }
        }

    }
}