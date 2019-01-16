using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Core.Models;
using BookManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Core.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenre _Genre;
        public GenreController(IGenre _IGenre)
        {
            _Genre = _IGenre;
        }
        public IActionResult Index()
        {
            return View(_Genre.All);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre model)
        {
            if (ModelState.IsValid)
            {
                _Genre.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            var student = _Genre.GetGenre(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var student = _Genre.GetGenre(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Genre.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var student = _Genre.GetGenre(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }


        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _Genre.Edit(genre);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}