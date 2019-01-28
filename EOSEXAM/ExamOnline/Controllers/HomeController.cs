using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using ExamOnline.ModelsView;

namespace ExamOnline.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUser _User;
        private readonly ISubject _Subject;
        private readonly IQuestion _Question;
        private readonly IAnswer _Answer;
        const string SessionUser = "_User";
        const string SessionSubject = "_Subject";

        public HomeController(IUser _IUser, ISubject _ISubject, IQuestion _IQuestion, IAnswer _IAnswer)
        {
            _User = _IUser;
            _Subject = _ISubject;
            _Question = _IQuestion;
            _Answer = _IAnswer;
        }

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
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToLocal(returnUrl, model);
                }
                var user = _User.Login(model.UserName, model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString(SessionUser, user.UserName);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.GivenName, user.Password),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToLocal(returnUrl, model);
                }
                else
                {
                    ViewBag.ErrorLogin = "Tên đăng nhập hoặc tài khoản không chính xác";
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Admin", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl, User model)
        {
            if(model.RoleId.Equals(1))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("SelectSubject", "Home");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult SelectSubject()
        {
            ViewData["User"] = HttpContext.Session.GetString(SessionUser);
            Subject subject = new Subject();
            subject.ListOfSubject = _Subject.GetAll();

            return View(subject);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SelectSubject(Subject model)
        {
            Subject SubjectSelected = _Subject.GetSubject(model.SubjectId);
            if (SubjectSelected != null)
            {
                HttpContext.Session.SetString(SessionSubject, SubjectSelected.SubjectName);
                return RedirectToAction("QuizTest");
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult QuizTest()
        {
            ViewData["User"] = HttpContext.Session.GetString(SessionUser);
            ViewData["Subject"] = HttpContext.Session.GetString(SessionSubject);
            IQueryable<Question> questions = null;

            if (ViewData["Subject"] != null)
            {
                questions = _Question.GetQuestionBySubjectName(HttpContext.Session.GetString(SessionSubject));
            }

            return View(questions);
        }

        [Authorize]
        [HttpPost]
        public ActionResult QuizTest(List<QuizAnswerVM> resultQuiz)
        {
            List<QuizAnswerVM> finalResultQuiz = new List<QuizAnswerVM>();

            foreach (QuizAnswerVM answser in resultQuiz)
            {
                QuizAnswerVM result = _Answer.GetAnswerByYourAnswer(answser);

                finalResultQuiz.Add(result);
            }

            return Json(new { result = finalResultQuiz });
        }
    }
}
