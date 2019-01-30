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
    public class AnswerController : Controller
    {
        private readonly IAnswer _Answer;
        private readonly IQuestion _Question;

        public AnswerController(IAnswer _IAnswer, IQuestion _IQuestion)
        {
            _Answer = _IAnswer;
            _Question = _IQuestion;
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
        public IActionResult Create(Answer model)
        {
            if (ModelState.IsValid)
            {
                _Answer.Add(model);
                return RedirectToAction("Index", "Question");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var answer = _Answer.GetAnswer(Id);
            if (answer == null)
            {
                return RedirectToAction("Index", "Question");
            }
            return View(answer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Answer.Remove(Id);
            return RedirectToAction("Index", "Question");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var answer = _Answer.GetAnswer(Id);
            if (answer == null)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Question> questions = _Question.All;
            ViewBag.ListOfQuestion = questions;
            return View(answer);
        }


        [HttpPost]
        public IActionResult Edit(Answer Answer)
        {
            if (ModelState.IsValid)
            {
                _Answer.Edit(Answer);
                return RedirectToAction("Index", "Question");
            }
            return View();
        }
    }

}