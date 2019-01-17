using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamCore.Models;
using ExamCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _User;

        public UserController(IUser _IUser)
        {
            _User = _IUser;
        }

        public IActionResult Index()
        {
            return View(_User.All);
        }

        [HttpGet]
        public IActionResult Create()
        {
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