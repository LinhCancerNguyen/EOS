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
        private readonly IAnswer _Answer;

        public QuestionController(IQuestion _IQuestion, ISubject _ISubject, IAnswer _IAnswer)
        {
            _Question = _IQuestion;
            _Subject = _ISubject;
            _Answer = _IAnswer;
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

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var user = _Question.GetQuestionById(Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Question.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var question = _Question.GetQuestionById(Id);
            if (question == null)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Subject> subjects = _Subject.All;
            ViewBag.ListOfSubject = subjects;
            return View(question);
        }

        [HttpPost]
        public IActionResult Edit(Question Question)
        {
            if (ModelState.IsValid)
            {
                _Question.Edit(Question);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}