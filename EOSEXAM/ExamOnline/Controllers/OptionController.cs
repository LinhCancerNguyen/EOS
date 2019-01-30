using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    public class OptionController : Controller
    {
        private readonly IQuestion _Question;
        private readonly ISubject _Subject;
        private readonly IAnswer _Answer;
        private readonly IOption _Option;

        public OptionController(IQuestion _IQuestion, ISubject _ISubject, IAnswer _IAnswer, IOption _IOption)
        {
            _Question = _IQuestion;
            _Subject = _ISubject;
            _Answer = _IAnswer;
            _Option = _IOption;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Question> questions = _Question.All;
            ViewBag.ListOfQuestion = questions;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Option model)
        {
            if (ModelState.IsValid)
            {
                _Option.Add(model);
                return RedirectToAction("Index", "Question");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var option = _Option.GetOption(Id);
            if (option == null)
            {
                return RedirectToAction("Index", "Question");
            }
            return View(option);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Option.Remove(Id);
            return RedirectToAction("Index", "Question");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var option = _Option.GetOption(Id);
            if (option == null)
            {
                return RedirectToAction("Index", "Question");
            }
            IEnumerable<Question> questions = _Question.All;
            ViewBag.ListOfQuestion = questions;
            return View(option);
        }

        [HttpPost]
        public IActionResult Edit(Option Option)
        {
            if (ModelState.IsValid)
            {
                _Option.Edit(Option);
                return RedirectToAction("Index", "Question");
            }
            return View();
        }
    }
}