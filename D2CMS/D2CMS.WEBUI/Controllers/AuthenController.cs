using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using D2CMS.CORE.AuthenticationModel;
using D2CMS.SERVICE.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace D2CMS.WEBUI.Controllers
{
    [Authorize]
    public class AuthenController : Controller
    {
        private readonly IConfiguration config;
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public AuthenController(IConfiguration config, IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.config = config;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Report");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LDAPLogin record)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Report");
            }
            var user = userService.Authenticate(config["LDAP:Url"], record);
            if (user != null)
            {
                user.Role = roleService.GetRole(user.RoleId);
                var expiredDateTime = DateTime.Now.AddMinutes(90);
                var claims = new List<Claim> {
                        new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString() + "5T14nHTu12GTh1tCh0D3pTr4i"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Account),
                        new Claim(ClaimTypes.Role, user.Role.Name),
                        new Claim(ClaimTypes.Expired, expiredDateTime.Ticks.ToString())
                };
                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Authorization");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Report");
            }
            ViewData["LoginErrorMessage"] = "Login error! Please verify your LDAP account.";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Authen");
        }
    }
}