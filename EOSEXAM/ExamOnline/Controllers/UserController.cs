using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUser _User;
        private readonly IRole _Role;

        public UserController(IUser _IUser, IRole _IRole)
        {
            _User = _IUser;
            _Role = _IRole;
        }

        public IActionResult Index()
        {
            return View(_User.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Role> roles = _Role.All;
            ViewBag.ListOfRole = roles;
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                _User.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var user = _User.GetUser(Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _User.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var user = _User.GetUser(Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Role> roles = _Role.All;
            ViewBag.ListOfRole = roles;
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(User User)
        {
            if (ModelState.IsValid)
            {
                _User.Edit(User);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}