using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamCore.Models;
using ExamCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamCore.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubject _Subject;

        public SubjectController(ISubject _ISubject)
        {
            _Subject = _ISubject;
        }

        public IActionResult Index()
        {
            return View(_Subject.All);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject model)
        {
            if (ModelState.IsValid)
            {
                _Subject.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var subject = _Subject.GetSubject(Id);
            if (subject == null)
            {
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Subject.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var subject = _Subject.GetSubject(Id);
            if (subject == null)
            {
                return RedirectToAction("Index");
            }
            return View(subject);
        }


        [HttpPost]
        public IActionResult Edit(Subject Subject)
        {
            if (ModelState.IsValid)
            {
                _Subject.Edit(Subject);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
