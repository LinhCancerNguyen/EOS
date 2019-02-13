using System;
using System.Collections.Generic;
using System.Linq;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.CORE.ModelViews;
using EXAMSYSTEM.SERVICE.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
namespace EXAMSYSTEM.WEBUI.Controllers
{
    [Authorize]
    public class UserExamController : Controller
    {
        private readonly IConfiguration config;
        private readonly IUserExamService userExamService;
        private readonly IUserService userService;
        private readonly ISubjectService subjectService;

        public UserExamController(IConfiguration config, IUserExamService userExamService, IUserService userService, ISubjectService subjectService)
        {
            this.userExamService = userExamService;
            this.userService = userService;
            this.subjectService = subjectService;
            this.config = config;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(string searchName, string searchSubject)
        {
            var userExams = userExamService.GetUserExams();
            if (!String.IsNullOrEmpty(searchName))
            {
                userExams = userExams.Where(s => s.User.Username.Contains(searchName));
            }
            if (!String.IsNullOrEmpty(searchSubject))
            {
                userExams = userExams.Where(s => s.Subject.SubjectName.Contains(searchSubject));
            }
            return View(userExams);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var userExam = userExamService.GetUserExam(Id);
            if (userExam == null)
            {
                return RedirectToAction("Index");
            }
            return View(userExam);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            userExamService.Delete(userExamService.GetUserExam(Id));
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var userExam = userExamService.GetUserExam(Id);
            if (userExam == null)
            {
                return RedirectToAction("Index");
            }
            IEnumerable<Subject> subjects = subjectService.GetSubjects();
            ViewBag.ListOfSubject = subjects;
            IEnumerable<UserView> users = userService.GetUsers();
            ViewBag.ListOfUser = users;
            return View(userExam);
        }


        [HttpPost]
        public IActionResult Edit(UserExam UserExam)
        {
            if (ModelState.IsValid)
            {
                userExamService.Update(UserExam);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}