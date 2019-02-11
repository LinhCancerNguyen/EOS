using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.CORE.ModelViews;
using EXAMSYSTEM.SERVICE.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EXAMSYSTEM.WEBUI.Controllers
{
    public class QuizzController : Controller
    {
        private readonly IConfiguration config;
        private readonly IUserExamService userExamService;
        private readonly IUserService userService;
        private readonly ISubjectService subjectService;
        private readonly IQuestionService questionService;

        const string SessionUser = "_User";
        const string SessionSubject = "_Subject";
        const string NumberQuestion = "_Number";

        public QuizzController(IConfiguration config, IUserExamService userExamService, IUserService userService, ISubjectService subjectService, IQuestionService questionService)
        {
            this.userExamService = userExamService;
            this.userService = userService;
            this.subjectService = subjectService;
            this.questionService = questionService;
            this.config = config;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Login(model.Username, model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString(SessionUser, user.Username);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.GivenName, user.Password),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("SelectSubject", "Quizz");
                }
                else
                {
                    ViewBag.ErrorLogin = "Tên đăng nhập hoặc tài khoản không chính xác";
                }
            }

            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("SelectSubject", "Quizz");
            }
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("SelectSubject", "Quizz");
        }

        [Authorize]
        [HttpGet]
        public IActionResult SelectSubject()
        {
            ViewData["User"] = HttpContext.Session.GetString(SessionUser);
            SubjectView subject = new SubjectView();
            if (ViewData["User"] != null)
            {
                subject.ListOfSubject = subjectService.GetAllSubjects();
                return View(subject);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult SelectSubject(SubjectView model)
        {
            Subject SubjectSelected = subjectService.GetSubject(model.SubjectId);
            if (SubjectSelected != null)
            {
                HttpContext.Session.SetString(SessionSubject, SubjectSelected.SubjectName);
                HttpContext.Session.SetString(NumberQuestion, model.NumberOfQuestion.ToString());
                return RedirectToAction("QuizTest");
            }

            return View();
        }
    }
}