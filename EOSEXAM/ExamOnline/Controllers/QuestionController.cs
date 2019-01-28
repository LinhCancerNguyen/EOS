using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestion _Question;
        private readonly ISubject _Subject;

        public QuestionController(IQuestion _IQuestion, ISubject _ISubject)
        {
            _Question = _IQuestion;
            _Subject = _ISubject;
        }

        public IActionResult Index()
        {
            return View(_Question.GetQuestion());
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Subject> subjects = _Subject.All;
            ViewBag.ListOfSubject = subjects;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Question model)
        {
            if (ModelState.IsValid)
            {
                _Question.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}