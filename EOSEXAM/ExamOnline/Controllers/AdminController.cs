using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUser _User;

        
        public AdminController(IUser _IUser)
        {
            _User = _IUser;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _User.Login(model.UserName, model.Password);
                if (user != null && user.Role.RoleName == "Admin")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.GivenName, user.Password),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ErrorLogin = "Tên đăng nhập hoặc tài khoản không chính xác";
                }
            }

            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}