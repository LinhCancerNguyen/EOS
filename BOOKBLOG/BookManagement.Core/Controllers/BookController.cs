using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Core.Models;
using BookManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Core.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _Book;

        public BookController(IBook _IBook)
        {
            _Book = _IBook;
        }

        public IActionResult Index()
        {
            return View(_Book.All);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _Book.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            var student = _Book.GetBook(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var student = _Book.GetBook(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Book.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var student = _Book.GetBook(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }


        [HttpPost]
        public IActionResult Edit(Book Book)
        {
            if (ModelState.IsValid)
            {
                _Book.Edit(Book);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}