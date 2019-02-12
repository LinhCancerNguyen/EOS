using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.SERVICE.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EXAMSYSTEM.WEBUI.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IConfiguration config;
        private readonly IQuestionService questionService;
        private readonly ISubjectService subjectService;

        public QuestionController(IConfiguration config, IQuestionService questionService, ISubjectService subjectService)
        {
            this.questionService = questionService;
            this.subjectService = subjectService;
            this.config = config;
        }

        public IActionResult Index()
        {
            return View(questionService.GetQuestions());
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Subject> subjects = subjectService.GetSubjects();
            ViewBag.ListOfSubject = subjects;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question model)
        {
            if (ModelState.IsValid)
            {
                questionService.CreateQuestion(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var question = questionService.GetQuestion(Id);
            if (question == null)
            {
                return RedirectToAction("Index");
            }
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            questionService.Delete(questionService.GetQuestion(Id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var question = questionService.GetQuestion(Id);
            if (question == null)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Subject> subjects = subjectService.GetSubjects();
            ViewBag.ListOfSubject = subjects;
            return View(question);
        }


        [HttpPost]
        public IActionResult Edit(Question Question)
        {
            if (ModelState.IsValid)
            {
                questionService.Update(Question);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}