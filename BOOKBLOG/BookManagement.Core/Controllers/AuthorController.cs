using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Core.Models;
using BookManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Core.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthor _Author;

        public AuthorController(IAuthor _IAuthor)
        {
            _Author = _IAuthor;
        }

        public IActionResult Index()
        {
            return View(_Author.All);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author model)
        {
            if (ModelState.IsValid)
            {
                _Author.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            var student = _Author.GetAuthor(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var student = _Author.GetAuthor(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Author.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var student = _Author.GetAuthor(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }


        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _Author.Edit(author);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
