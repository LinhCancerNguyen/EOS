using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.SERVICE.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EXAMSYSTEM.WEBUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IConfiguration config;
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public UserController(IConfiguration config, IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.config = config;
        }

        public IActionResult Index()
        {
            return View(userService.GetUsers());
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Role> roles = roleService.GetRoles();
            ViewBag.ListOfRole = roles;
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                userService.CreateUser(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var user = userService.GetUser(Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            userService.Delete(userService.GetUser(Id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var user = userService.GetUser(Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Role> roles = roleService.GetRoles();
            ViewBag.ListOfRole = roles;
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(User User)
        {
            if (ModelState.IsValid)
            {
                userService.Update(User);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}