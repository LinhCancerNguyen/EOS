using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D2CMS.SERVICE.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2CMS.WEBUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;        
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserController(IUserService userService, IRoleService roleService, IReportService reportService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this.roleService = roleService;            
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var users = userService.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult MyProfile()
        {
            var user = userService.GetUser(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            var user = userService.GetUser(User.Identity.Name);
            return View(user);
        }
    }
}