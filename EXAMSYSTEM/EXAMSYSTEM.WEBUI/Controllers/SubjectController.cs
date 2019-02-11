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
    public class SubjectController : Controller
    {
        private readonly IConfiguration config;
        private readonly ISubjectService subjectService;

        public SubjectController(IConfiguration config, ISubjectService subjectService)
        {
            this.subjectService = subjectService;
            this.config = config;
        }

        public IActionResult Index()
        {
            return View(subjectService.GetSubjects());
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
                subjectService.CreateSubject(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var subject = subjectService.GetSubject(Id);
            if (subject == null)
            {
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            subjectService.Delete(subjectService.GetSubject(Id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var subject = subjectService.GetSubject(Id);
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
                subjectService.Update(Subject);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}